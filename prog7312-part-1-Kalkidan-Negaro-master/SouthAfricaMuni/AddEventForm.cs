using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SouthAfricaMuni
{
    public partial class AddEventForm : Form
    {
        // Dictionary to store events
        private Dictionary<DateTime, HashSet<EventDetails>> eventsDictionary;

        public AddEventForm(Dictionary<DateTime, HashSet<EventDetails>> events)
        {
            InitializeComponent();
            eventsDictionary = events; // Reference to the passed-in dictionary
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            // Retrieve input values
            string eventName = txtEventName.Text.Trim();
            string eventLocation = txtEventLocation.Text.Trim();
            DateTime eventDate = dtpEventDate.Value; // Use DateTime directly
            string eventDescription = txtEventDescription.Text.Trim();
            string eventCategory = cmbCategory.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(eventCategory))
            {
                MessageBox.Show("Please select a category.");
                return;
            }

            // Create a new EventDetails object
            var eventDetails = new EventDetails
            {
                Name = eventName,
                Location = eventLocation,
                Date = eventDate.ToString("yyyy-MM-dd"), // Store the date as a string
                Description = eventDescription,
                Category = eventCategory // Assign selected category
            };

            // Check if the date already exists in the dictionary
            if (!eventsDictionary.ContainsKey(eventDate))
            {
                eventsDictionary[eventDate] = new HashSet<EventDetails>(); // Initialize a new HashSet for this date
            }

            // Add the event to the HashSet for that date
            if (eventsDictionary[eventDate].Add(eventDetails))
            {
                MessageBox.Show("Event successfully added.");
                this.Close(); // Close the form after adding the event

                /***************************************************************************************
                Stack Overflow -Dictionary in C#
                Title: How to Use Dictionary in C#
                Author: Community members(Stack Overflow)
                Date: Ongoing updates
                Code version: Latest
                Availability: https://stackoverflow.com/questions/18821202/using-dictionary-in-c-sharp
                ***************************************************************************************/
            }
            else
            {
                MessageBox.Show("An event with this name already exists on this date.");
            }

            // Clear input fields after submission
            ClearFields();
        }


        private void ClearFields()
        {
            txtEventName.Clear();
            txtEventLocation.Clear();
            txtEventDescription.Clear();
            dtpEventDate.Value = DateTime.Now; // Reset date to current date
            cmbCategory.SelectedIndex = -1; // Reset category selection
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form
        }

        private void AddEventForm_Load(object sender, EventArgs e)
        {

        }
    }
}
public class EventDetails
{
    public string Name { get; set; }
    public string Location { get; set; }
    public string Date { get; set; }
    public string Description { get; set; }
    public string Category { get; set; } 
}