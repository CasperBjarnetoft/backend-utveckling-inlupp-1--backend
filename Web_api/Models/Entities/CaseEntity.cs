namespace Web_api.Models.Entities
{
    public class CaseEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public string Subject { get; set; }
        public string Descripation { get; set; }

        public int StatusId { get; set; } = 1;
        public StatusEntity Status { get; set; }

        //en lista med massa kommentarer
        public ICollection<CommentEntity> Comments { get; set; }
    }
}
