using System;
using System.Drawing;
using System.Windows.Forms;

namespace SouthAfricaMuni
{
    public partial class DescriptionForm : Form
    {
        private EventDetails eventDetails;

        public DescriptionForm(EventDetails eventDetails)
        {
            InitializeComponent();
            this.eventDetails = eventDetails;
            LoadEventDetails();
            ApplyStyles(); // Apply custom styles
        }

        private void LoadEventDetails()
        {
            lblEventName.Text = eventDetails.Name;
            lblLocation.Text = $"Location: {eventDetails.Location}";
            lblDate.Text = $"Date: {eventDetails.Date}";
            lblCategory.Text = $"Category: {eventDetails.Category}";
            txtDescription.Text = eventDetails.Description;
        }

        private void ApplyStyles()
        {
            // Set form properties
            this.BackColor = Color.FromArgb(240, 240, 240); // Light gray background
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Fixed dialog border
            this.StartPosition = FormStartPosition.CenterParent; // Center on parent

            // Style labels
            lblEventName.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblEventName.ForeColor = Color.FromArgb(50, 80, 150); // Dark blue
            lblEventName.AutoSize = true;
            lblLocation.Font = new Font("Segoe UI", 12F);
            lblDate.Font = new Font("Segoe UI", 12F);
            lblCategory.Font = new Font("Segoe UI", 12F);

            // Style text box
            txtDescription.BackColor = Color.FromArgb(255, 255, 255); // White background
            txtDescription.ForeColor = Color.FromArgb(40, 40, 40); // Dark gray text
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Multiline = true;
            txtDescription.ReadOnly = true;
            txtDescription.ScrollBars = ScrollBars.Vertical;

            // Style button
            btnClose.BackColor = Color.FromArgb(50, 150, 50); // Green background
            btnClose.ForeColor = Color.White; // White text
            btnClose.FlatStyle = FlatStyle.Flat; // Flat button style
            btnClose.FlatAppearance.BorderSize = 0; // Remove border
            btnClose.Font = new Font("Segoe UI", 12F);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form when the button is clicked
        }
    }
}
