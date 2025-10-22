using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SouthAfricaMuni
{
    public partial class ReportIssuesForm : Form
    {
        // Static counter to keep track of the number of submitted forms
        private static int submissionCount = 5;
        private MaxHeap issueHeap = new MaxHeap();
       



        // List to store all submitted issues
        public static List<IssueReport> issuesList = new List<IssueReport>();

        public ReportIssuesForm()
        {
            InitializeComponent();
            issueHeap = new MaxHeap();
        }

        private void TxtLocation_Enter(object sender, EventArgs e)
        {
            if (rtbLocation.Text == "Enter location...")
            {
                rtbLocation.Text = "";
                rtbLocation.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void TxtLocation_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtbLocation.Text))
            {
                rtbLocation.Text = "Enter location...";
                rtbLocation.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void BtnAttachMedia_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png|Documents|*.pdf;*.docx";
                openFileDialog.Title = "Select a file to attach";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Handle file attachment logic here
                    MessageBox.Show("File attached: " + openFileDialog.FileName);
                }
            }
        }

        public void Alert(string message)
        {
            MessageBox.Show(message, "Submission Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            string location = rtbLocation.Text;
            string category = cmbCategory.SelectedItem?.ToString();
            string description = rtbDescription.Text;

            // Ensure location is valid
            if (location == "Enter location..." || string.IsNullOrWhiteSpace(location))
            {
                MessageBox.Show("Please fill out the location.");
                return;
            }

            // Ensure a category is selected
            if (string.IsNullOrEmpty(category))
            {
                MessageBox.Show("Please select a category.");
                return;
            }

            // Ensure description is not empty
            if (string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Please enter a description.");
                return;
            }

            // Generate a unique Issue ID
            submissionCount++;
            string issueId = "" + submissionCount.ToString("D3"); 

           

            // Create a new IssueReport instance
            IssueReport newIssue = new IssueReport(issueId, location, category, description, DateTime.Now)
            {
                ReportedDate = DateTime.Now // Set the report date as the current date
            };

            // Add the new issue to the list
            issuesList.Add(newIssue);

            // Insert the new issue into the heap to maintain priority order
            issueHeap.Insert(newIssue);

            // Update the label with the submission count
            lblEngagement.Text = $"Forms submitted. Thank you for your feedback.";

            // Show alert with the Issue ID
            Alert($"Issue reported successfully! Your Issue ID is {issueId}");

            // Reload the DataGridView and TreeView with the updated list of issues
            LoadIssuesFromHeap();
            LoadIssueCategories(issuesList);

            // Simulate report submission and clear the form
            ClearForm();
        }

        private void LoadIssuesFromHeap()
        {
            
           ClearForm(); // Clear existing rows

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

        // Update method to load issues into the TreeView categorized by their category
        private void LoadIssueCategories(List<IssueReport> issues)
        {
            
            treeViewCategories.Nodes.Clear(); // Clear existing nodes

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


        private void BtnBackToMain_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearForm()
        {
            rtbLocation.Text = "Enter location...";
            rtbLocation.ForeColor = System.Drawing.Color.Gray;
            cmbCategory.SelectedIndex = -1;
            rtbDescription.Clear();
        }

        private void ReportIssuesForm_Load(object sender, EventArgs e)
        {
        }

        private void ReportIssuesForm_Load_1(object sender, EventArgs e)
        {
        }
    }

}

/***************************************************************************************
*    Title: MaxHeap Implementation in C#
*    Author: TutorialsPoint
*    Date: Ongoing updates
*    Code version: Latest
*    Availability: https://www.tutorialspoint.com/csharp/csharp_maxheap.htm
***************************************************************************************/

/***************************************************************************************
*    Title: TreeView Control in C#
*    Author: Microsoft Docs
*    Date: Ongoing updates
*    Code version: Latest
*    Availability: https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.treeview?view=windowsdesktop-7.0
***************************************************************************************/

/***************************************************************************************
*    Title: DataGridView in C#
*    Author: Microsoft Docs
*    Date: Ongoing updates
*    Code version: Latest
*    Availability: https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.datagridview?view=windowsdesktop-7.0
***************************************************************************************/

/***************************************************************************************
*    Title: OpenFileDialog in C#
*    Author: Microsoft Docs
*    Date: Ongoing updates
*    Code version: Latest
*    Availability: https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.openfiledialog?view=windowsdesktop-7.0
***************************************************************************************/

/***************************************************************************************
*    Title: List in C#
*    Author: Microsoft Docs
*    Date: Ongoing updates
*    Code version: Latest
*    Availability: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-7.0
***************************************************************************************/
