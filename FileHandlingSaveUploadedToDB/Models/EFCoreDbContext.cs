using Microsoft.EntityFrameworkCore;

namespace FileUploadAspNetCore2.Models
{
    public class EFCoreDbContext : DbContext
    {
        public EFCoreDbContext() : base()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Configuring the Connection String
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-HBJN9F2\SQLEXPRESS;Database=FileHandlingDB;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        //Adding Domain Classes as DbSet Properties
        public DbSet<FileModel> Files { get; set; }
    }
}
