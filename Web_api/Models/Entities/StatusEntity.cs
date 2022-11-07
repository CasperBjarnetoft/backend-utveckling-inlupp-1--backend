namespace Web_api.Models.Entities
{
    public class StatusEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }    

        public ICollection<CaseEntity> Cases { get; set; }
    }
}
