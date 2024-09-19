using Microsoft.EntityFrameworkCore;

namespace FileUploadDataToExcelAspNetCore3.Models
{
    public class EFCoreDbContext : DbContext
    {
        public EFCoreDbContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-HBJN9F2\SQLEXPRESS;Database=FileHandlingDB1;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        //Adding Domain Classes as DbSet Properties
        //it will create Employees table modelling Employee class
        public DbSet<Employee> Employees { get; set;}

        //After this run Add-Migration MigName and Update-Database commands in Package Manager Console
    }
}
