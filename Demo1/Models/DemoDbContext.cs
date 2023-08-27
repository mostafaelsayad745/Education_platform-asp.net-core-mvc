using Microsoft.EntityFrameworkCore;
namespace Demo1.Models
{
    public class DemoDbContext : DbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =.; Database=mdb1;Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
