using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace News.Models
{
    public class Comment
    {
        public int commentID { get; set; }

        public Guid createdBy { get; set; }

        [Required]
        public string? comment { get; set; }

        public int reportId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime dateCreated { get; set; }
    }
}
