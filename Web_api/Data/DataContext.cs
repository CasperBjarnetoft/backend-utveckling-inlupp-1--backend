using Microsoft.EntityFrameworkCore;
using Web_api.Models.Entities;

namespace Web_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        
        public DbSet<StatusEntity> Statuses { get; set; }
        public DbSet<CaseEntity> Cases { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
}
}
