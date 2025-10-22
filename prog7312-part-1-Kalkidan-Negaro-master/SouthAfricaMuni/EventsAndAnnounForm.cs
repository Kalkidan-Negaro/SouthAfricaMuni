using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SouthAfricaMuni
{
    public partial class EventsAndAnnounForm : Form
    {
        private Dictionary<DateTime, HashSet<EventDetails>> eventsDictionary; // Dictionary to store events by date
        private PriorityQueue<EventDetails> eventQueue = new PriorityQueue<EventDetails>();

        public EventsAndAnnounForm()
        {
            InitializeComponent();
            ConfigureDataGridView();
            eventsDictionary = new Dictionary<DateTime, HashSet<EventDetails>>(); // Initialize the events dictionary
            LoadEvents();
            SetPlaceholderText();
        }

        private void ConfigureDataGridView()
        {
            // Clear any existing columns
            dgvEvents.Columns.Clear();

            // Add the Event Name, Location, Date, and Category columns
            dgvEvents.Columns.Add("EventName", "Event Name");
            dgvEvents.Columns.Add("Location", "Location");
            dgvEvents.Columns.Add("Date", "Date");
            dgvEvents.Columns.Add("Category", "Category"); // New Category column

            // Create View Description button column
            DataGridViewButtonColumn viewDescriptionButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "View Description",
                Name = "btnViewDescription",
                Text = "View",
                UseColumnTextForButtonValue = true
            };

            // Add the button column last
            dgvEvents.Columns.Add(viewDescriptionButtonColumn);

            // Style DataGridView
            dgvEvents.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvEvents.RowHeadersVisible = false;
            dgvEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Alternate row colors
            dgvEvents.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvEvents.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }

        private void LoadEvents(string searchQuery = "")
        {
            // Clear existing rows before loading
            dgvEvents.Rows.Clear();
            eventQueue = new PriorityQueue<EventDetails>(); // Reset the priority queue

            // Load events into the priority queue
            foreach (var eventEntry in eventsDictionary.Values)
            {
                // Iterate over the HashSet<EventDetails>
                foreach (var ev in eventEntry) // Ensure you iterate through the HashSet
                {
                    // Check if the event matches the search query
                    if (IsEventMatchingSearch(ev, searchQuery))
                    {
                        // Calculate priority based on how close the event is
                        int priority = CalculatePriority(ev.Date);
                        eventQueue.Enqueue(ev, priority);
                    }
                }
            }

            // Display events in order of priority
            while (!eventQueue.IsEmpty)
            {
                var ev = eventQueue.Dequeue();
                dgvEvents.Rows.Add(ev.Name, ev.Location, ev.Date, ev.Category);
            }
        }

        private bool IsEventMatchingSearch(EventDetails ev, string searchQuery)
        {
            // Return true if searchQuery is empty
            if (string.IsNullOrWhiteSpace(searchQuery) || searchQuery == "Search events...")
                return true;

            // Convert to lowercase for case insensitive comparison
            string lowerQuery = searchQuery.ToLower();

            // Check for matches in Name, Location, Date, or Category
            return ev.Name.ToLower().Contains(lowerQuery) ||
                   ev.Location.ToLower().Contains(lowerQuery) ||
                   ev.Date.ToLower().Contains(lowerQuery) ||
                   ev.Category.ToLower().Contains(lowerQuery);
        }

        private int CalculatePriority(string eventDate)
        {
            DateTime eventDateTime = DateTime.Parse(eventDate);
            TimeSpan timeUntilEvent = eventDateTime - DateTime.Now;

            // Return priority as the total days until the event (lower is more urgent)
            return (int)Math.Max(0, timeUntilEvent.TotalDays);
        }

        private void dgvEvents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the button column was clicked
            if (e.ColumnIndex == dgvEvents.Columns["btnViewDescription"].Index && e.RowIndex >= 0)
            {
                // Get the selected event's name
                string eventName = dgvEvents.Rows[e.RowIndex].Cells["EventName"].Value.ToString();

                // Find the event details by name
                var eventDetail = eventsDictionary
                    .SelectMany(pair => pair.Value)
                    .FirstOrDefault(ev => ev.Name.Equals(eventName, StringComparison.OrdinalIgnoreCase)); // Case insensitive comparison

                if (eventDetail != null)
                {
                    // Create an instance of the DescriptionForm, passing the event details
                    DescriptionForm descriptionForm = new DescriptionForm(eventDetail);

                    // Hide the current form and show the DescriptionForm
                    this.Hide();
                    descriptionForm.ShowDialog();
                    this.Show(); // Show the current form again after closing the DescriptionForm
                }
                else
                {
                    MessageBox.Show("Event details not found."); // Inform the user if not found
                }
            }
        }


        private void BtnBackToMain_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form
        }

        private void BtnAddEvent_Click(object sender, EventArgs e)
        {
            // Open the AddEventForm and pass the eventsDictionary
            AddEventForm addEventForm = new AddEventForm(eventsDictionary);
            addEventForm.ShowDialog(); // Show the form as a dialog

            // Refresh the displayed events after adding a new event
            LoadEvents();
        }

        private void SetPlaceholderText()
        {
            // Set placeholder text for the search textbox
            txtSearch.Text = "Search events...";
            txtSearch.ForeColor = Color.Gray;

            txtSearch.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = "Search events...";
                    txtSearch.ForeColor = Color.Gray;
                }
            };

            txtSearch.Enter += (s, e) =>
            {
                if (txtSearch.Text == "Search events...")
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = Color.Black;
                }
            };

            // Add event handler for text changed
            txtSearch.TextChanged += (s, e) => LoadEvents(txtSearch.Text);
        }
    }

    public class EventDetails : IEquatable<EventDetails>
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; } 

        public bool Equals(EventDetails other)
        {
            if (other == null) return false;

            return Name == other.Name && Date == other.Date; // Define equality based on Name and Date
        }

        public override int GetHashCode()
        {
            // Combine hash codes for Name and Date for the HashSet
            return (Name.GetHashCode() * 397) ^ Date.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as EventDetails);
        }
    }
}
/***************************************************************************************
*    Title: Using HashSet in C#
*    Author: TutorialsPoint
*    Date: Ongoing updates
*    Code version: Latest
*    Availability: https://www.tutorialspoint.com/csharp/csharp_hashset.htm
***************************************************************************************/
