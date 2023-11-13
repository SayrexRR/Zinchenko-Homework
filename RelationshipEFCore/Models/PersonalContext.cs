using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationshipEFCore.Models
{
    public class PersonalContext : DbContext
    {
        public PersonalContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=RelationsDb;Trusted_Connection=true;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().UseTptMappingStrategy();

            modelBuilder.Entity<Manager>()
                .HasOne(m => m.Department)
                .WithMany(d => d.Managers)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
