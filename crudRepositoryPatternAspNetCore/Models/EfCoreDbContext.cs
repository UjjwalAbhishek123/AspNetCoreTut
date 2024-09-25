using Microsoft.EntityFrameworkCore;

namespace crudRepositoryPatternAspNetCore.Models
{
    public class EfCoreDbContext : DbContext
    {
        //Constructor calling the Base DbContext
        //Class Constructor
        public EfCoreDbContext(DbContextOptions<EfCoreDbContext> options) : base(options) 
        {

        }

        //OnConfiguring() method is used to
        //select and configure the data source
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //connection string will be in appSetting.json 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        //Adding Domain classes as DbSet (Table of DB) Properties
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
