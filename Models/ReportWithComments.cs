using News.Data;
using System.Collections.Generic;

namespace News.Models
{
    public class ReportWithComments
    {
        public Report Report { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
