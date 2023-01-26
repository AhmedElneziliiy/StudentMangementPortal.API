using Microsoft.EntityFrameworkCore;

namespace StudentMangementPortal.API.Data.Models
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options):base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
         public DbSet<Gender> Genders { get; set; }
         public DbSet<Gender> Addresss { get; set; }
       
    }
}
