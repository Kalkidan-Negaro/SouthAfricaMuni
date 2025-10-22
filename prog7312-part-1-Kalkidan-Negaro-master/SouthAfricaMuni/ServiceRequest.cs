using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SouthAfricaMuni
{
    public partial class ServiceRequest : Form
    {
        private List<IssueReport> issues;
        private MaxHeap issueHeap;

        public ServiceRequest(List<IssueReport> issues)
        {
            InitializeComponent();
            
            // Initialize the issues list with the passed parameter or empty list
            this.issues = issues ?? new List<IssueReport>();

            issueHeap = new MaxHeap();

            // Insert all issues into the heap
            foreach (var issue in this.issues)
            {
                issueHeap.Insert(issue);
            }
           
            LoadIssuesFromHeap();
            LoadIssueCategories(this.issues);

            AddInitialIssues();

        }

        private void AddInitialIssues()
        {
            // Adding 5 issues with real locations, short descriptions, and specific dates
            issues.Add(new IssueReport("001", "New York, USA", "Potholes", "A large pothole near Times Square causing traffic disruptions.", new DateTime(2024, 11, 15)));
            issues.Add(new IssueReport("002", "London, UK", "Street Lights", "Several street lights on Oxford Street are malfunctioning, causing safety concerns.", new DateTime(2024, 11, 14)));
            issues.Add(new IssueReport("003", "Sydney, Australia", "Graffiti", "Graffiti on the walls near Circular Quay, affecting the aesthetics of the area.", new DateTime(2024, 11, 13)));
            issues.Add(new IssueReport("004", "Tokyo, Japan", "Littering", "Litter accumulating along the streets near Shibuya Crossing, attracting pests.", new DateTime(2024, 11, 12)));
            issues.Add(new IssueReport("005", "Cape Town, South Africa", "Street Signs", "A missing street sign near the Waterfront area, confusing drivers.", new DateTime(2024, 11, 11)));

            // Insert all the issues into the heap
            foreach (var issue in issues)
            {
                issueHeap.Insert(issue);
            }
        }


        // Load issues into the DataGridView using the MaxHeap
        private void LoadIssuesFromHeap()
        {
            dgvIssues.Rows.Clear();

            // Extract all issues from the heap in priority order
            var orderedIssues = new List<IssueReport>();
            while (!issueHeap.IsEmpty())
            {
                orderedIssues.Add(issueHeap.RemoveMax());
            }

            // Reload the heap after ordering to maintain data
            foreach (var issue in orderedIssues)
            {
                issueHeap.Insert(issue);
            }

            // Add ordered issues to the DataGridView
            foreach (var issue in orderedIssues)
            {
                dgvIssues.Rows.Add(issue.IssueId, issue.Location, issue.Category, issue.ReportedDate.ToString("g"));
            }
        }

        // Load issue categories into the TreeView
        private void LoadIssueCategories(List<IssueReport> issues)
        {
            // Clear existing nodes
            treeViewCategories.Nodes.Clear();

            // Group issues by category
            var groupedIssues = issues.GroupBy(issue => issue.Category).ToList();

            foreach (var categoryGroup in groupedIssues)
            {
                // Create a node for each category
                TreeNode categoryNode = new TreeNode(categoryGroup.Key);

                foreach (var issue in categoryGroup)
                {
                    // Create sub-nodes for each issue under the corresponding category
                    TreeNode issueNode = new TreeNode($"Issue {issue.IssueId} - {issue.Location}");
                    categoryNode.Nodes.Add(issueNode);
                }

                // Add the category node to the tree view
                treeViewCategories.Nodes.Add(categoryNode);
            }
        }

        // Event handler for 'View' button in the DataGridView
        private void dgvIssues_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure that the click is on the 'View' button column (index 3)
            if (e.ColumnIndex == 3)
            {
                // Retrieve the IssueID, Category, and Location from the clicked row
                var issueID = dgvIssues.Rows[e.RowIndex].Cells[0].Value.ToString(); // IssueID is in the first column
                var category = dgvIssues.Rows[e.RowIndex].Cells[2].Value.ToString(); // Category is in the third column
                var location = dgvIssues.Rows[e.RowIndex].Cells[1].Value.ToString(); // Location is in the second column

                // Display the details in a MessageBox
                MessageBox.Show($"Issue Details:\n" +
                                 $"Issue ID: {issueID}\n" +
                                 $"Category: {category}\n" +
                                 $"Location: {location}");
            }
        }

        // Search functionality to filter issues
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text.ToLower();

            // Filter issues by matching Issue ID, Location, or Category
            var filteredIssues = issues.Where(issue =>
                issue.IssueId.ToLower().Contains(searchQuery) || // Check if IssueId matches
                issue.Location.ToLower().Contains(searchQuery) || // Check if Location matches
                issue.Category.ToLower().Contains(searchQuery)    // Check if Category matches
            ).ToList();

            // Update DataGridView and TreeView with filtered results
            LoadIssues(filteredIssues);
            LoadIssueCategories(filteredIssues);
        }

        // Load filtered issues into DataGridView
        private void LoadIssues(List<IssueReport> issues)
        {
            dgvIssues.Rows.Clear();
            foreach (var issue in issues.OrderByDescending(i => i.ReportedDate)) // Order by reported date for display
            {
                dgvIssues.Rows.Add(issue.IssueId, issue.Location, issue.Category, issue.ReportedDate.ToString("g"));
            }
        }

        // Event handler for submitting a new issue
        private void BtnSubmitIssue_Click(object sender, EventArgs e)
        {
            var reportIssuesForm = new ReportIssuesForm();
            reportIssuesForm.FormClosed += (s, args) => LoadIssuesFromHeap(); // Refresh issues when returning
            reportIssuesForm.Show();
            this.Hide();
        }

        // Event handler to go back to the main menu
        private void BtnBackToMain_Click(object sender, EventArgs e)
        {
            var mainMenuForm = new Form1();
            mainMenuForm.Show();
            this.Hide();
        }

        // Reset the form state when navigating between forms
        private void ResetForm()
        {
            txtSearch.Clear();
            dgvIssues.Rows.Clear();
            treeViewCategories.Nodes.Clear();
        }
    }
}

/***************************************************************************************
*    Title: Filtering DataGridView with LINQ
*    Author: Stack Overflow Community
*    Date: Ongoing updates
*    Code version: Latest
*    Availability: https://stackoverflow.com/questions/2174903/filtering-datagridview-using-linq-in-c-sharp
***************************************************************************************/
/***************************************************************************************
*    Title: C# MaxHeap Implementation and Priority Queues
*    Author: GeeksforGeeks
*    Date: Ongoing updates
*    Code version: Latest
*    Availability: https://www.geeksforgeeks.org/heap-data-structure-in-c-sharp/
***************************************************************************************/

