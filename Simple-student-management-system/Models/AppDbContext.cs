using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Simple_student_management_system.Models;

namespace Simple_student_management_system.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; } 
        public DbSet<Course> Courses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source = .; Initial catalog = StudentManagement ; integrated security = True; TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }   
    }
}
