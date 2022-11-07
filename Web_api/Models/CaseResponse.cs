using Web_api.Models.Entities;

namespace Web_api.Models
{
    public class CaseResponse
    {
        public int Id { get; set; }
        public DateTime Created { get; set; } 
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
    }
}
