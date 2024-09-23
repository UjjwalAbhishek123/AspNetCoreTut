using Microsoft.EntityFrameworkCore;

namespace CodeFirstEFcoreAspNetCore.Models
{
    public class StudentDbContext : DbContext
    {
        //base() will call the constructor of parent class
        public StudentDbContext(DbContextOptions options) : base(options)
        {
            
        }

        //create DbSet<ModelClassName> name { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
