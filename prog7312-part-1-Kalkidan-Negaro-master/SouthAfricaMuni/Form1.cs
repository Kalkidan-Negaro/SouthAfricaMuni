using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SouthAfricaMuni
{
    public partial class Form1 : Form
    {
        private ToolTip toolTip;

        public Form1()
        {
            InitializeComponent();
            toolTip = new ToolTip();
            toolTip.SetToolTip(btnServiceRequestStatus, "Will be implemented soon.");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void BtnReportIssues_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReportIssuesForm reportIssuesForm = new ReportIssuesForm();
            reportIssuesForm.ShowDialog();
            this.Show();
        }

        private void btnLocalEvents_Click(object sender, EventArgs e)
        {
            this.Hide();
            EventsAndAnnounForm eventsAndAnnouncementsForm = new EventsAndAnnounForm();
            eventsAndAnnouncementsForm.ShowDialog();
            this.Show();
        }

        private void BtnServiceRequestStatus_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            ReportIssuesForm reportIssuesForm = new ReportIssuesForm();
            List<IssueReport> issues = ReportIssuesForm.issuesList;
            ServiceRequest serviceRequest = new ServiceRequest(issues);
            serviceRequest.ShowDialog();
            this.Show();
        }


    }
}