using System.ComponentModel.DataAnnotations;

namespace Web_api.Models.Entities
{
    public class CommentEntity
    {
        [Key]
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Created{ get; set; } = DateTime.Now;  

        public int CaseId { get; set; }
        public CaseEntity Case { get; set; }
    }
}
