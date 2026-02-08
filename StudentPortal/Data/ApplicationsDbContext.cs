using Microsoft.EntityFrameworkCore;
using StudentPortal.Models.Entites;

namespace StudentPortal.Data
{
    public class ApplicationsDbContext :DbContext
    {
        public ApplicationsDbContext(DbContextOptions<ApplicationsDbContext> options) : base(options)
        {
            
        }
        public DbSet<Student> Students{ get; set; }
        public DbSet<Courses> Courses { get; set; }
    }
}
