using Microsoft.EntityFrameworkCore;

namespace sample_crud_base.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Student { get; set; }

    }
}
