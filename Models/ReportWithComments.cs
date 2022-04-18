
namespace News.Models
{
    public class ReportWithComments
    {
        public Report Report { get; set; }

        public List<Comment> Comment { get; set; }
    }
}
