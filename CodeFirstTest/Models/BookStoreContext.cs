using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTest.Models
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext()
        {
            
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=BookStore;Trusted_Connection=True;TrustServerCertificate=true;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(m =>
            {
                m.Property(b => b.Name)
                .HasMaxLength(200)
                .IsRequired(true);

                m.Property(b => b.Author)
                .HasMaxLength(250)
                .IsRequired(true);

                m.Property(b => b.Description)
                .HasMaxLength(500);

                m.ToTable(b => b.HasCheckConstraint("CK_Prices", "[Price] >= 0"));

                m.HasMany(b => b.Genres).WithMany(g => g.Books);

                m.HasMany(b => b.OrderDetails).WithOne(od => od.Book).HasForeignKey(od => od.BookId);
            });

            modelBuilder.Entity<Genre>()
                .Property(b => b.Name)
                .HasMaxLength(100);

            modelBuilder.Entity<Client>(m =>
            {
                m.Property(c => c.FirstName)
                .HasMaxLength(150)
                .IsRequired(true);

                m.Property(c => c.LastName)
                .HasMaxLength(150)
                .IsRequired(true);

                m.HasMany(c => c.Orders).WithOne(o => o.Client).HasForeignKey(o => o.ClientId);
            });

            modelBuilder.Entity<Order>(m =>
            {
                m.HasMany(o => o.OrderDetails).WithOne(od => od.Order).HasForeignKey(od => od.OrderId);
            });

            modelBuilder.Entity<OrderDetail>().HasKey(c => new { c.OrderId, c.Position});

            modelBuilder.Entity<Employee>(m =>
            {
                m.Property(e => e.FirstName)
                .HasMaxLength(150)
                .IsRequired(true);

                m.Property(e => e.LastName)
                .HasMaxLength(150)
                .IsRequired(true);

                m.HasMany(e => e.Orders).WithOne(o => o.Employee).HasForeignKey(o => o.EmployeeId);

                m.HasOne(e => e.Position).WithOne(p => p.Employee).HasForeignKey<Position>(p => p.EmployeeId);
            });

            modelBuilder.Entity<Position>().HasKey(p => p.EmployeeId);

            modelBuilder.Entity<Position>()
                .Property(p => p.Name)
                .HasMaxLength(200)
                .IsRequired(true);
        }
    }
}
