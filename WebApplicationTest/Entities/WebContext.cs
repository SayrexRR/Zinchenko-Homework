using Microsoft.EntityFrameworkCore;
using WebApplicationTest.DataLayer.Entities;

namespace WebApplicationTest.DataLayer
{
    public class WebContext : DbContext
    {
        public WebContext() 
        {
            Database.EnsureCreated();
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=TestWebDb;Trusted_Connection=True;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(
                new Account { Id = 1, Name = "Alan", Password = "alan12_43" },
                new Account { Id = 2, Name = "Mike", Password = "m1ke1995" },
                new Account { Id = 3, Name = "Kate", Password = "22kate" },
                new Account { Id = 4, Name = "Marta", Password = "m@rt@20" },
                new Account { Id = 5, Name = "Tomas", Password = "t2000anders" });

            modelBuilder.Entity<Contact>().HasData(
                new Contact { Id = 1, Name = "Stiv", Email = "stiv20@gmail.com", Phone = "+380901567824" },
                new Contact { Id = 2, Name = "Victoria", Email = "vic1998@outlook.com" },
                new Contact { Id = 3, Name = "Bill", Email = "bill94trust@gmail.com" },
                new Contact { Id = 4, Name = "Amanda", Email = "amanda134@gmail.com", Phone = "+380683571568" },
                new Contact { Id = 5, Name = "Alex", Email = "alex2000@gmail.com" });
        }
    }
}
