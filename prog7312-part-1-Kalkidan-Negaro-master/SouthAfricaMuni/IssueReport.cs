using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthAfricaMuni
{
    public class IssueReport
    {
        public string IssueId { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public DateTime ReportedDate { get; set; }

        public IssueReport(string issueId, string location, string category, string description, DateTime reportedDate)
        {
            IssueId = issueId;
            Location = location;
            Category = category;
            Description = description;
            ReportedDate = DateTime.Now;
        }
    }
}

