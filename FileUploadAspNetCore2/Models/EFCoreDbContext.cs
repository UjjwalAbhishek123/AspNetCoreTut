using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-HBJN9F2\SQLEXPRESS;Database=FileHandlingDB1;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        //Adding Domain Classes as DbSet Properties
        public DbSet<FileModel> Files { get; set; }

        //After this run Add-Migration MigName and Update-Database commands in Package Manager Console
    }
}
