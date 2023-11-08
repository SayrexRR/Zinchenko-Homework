using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Models;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<ContactInfo> ContactInfoes { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderPosition> OrderPositions { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductInventory> ProductInventories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Test;Trusted_Connection=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Addresse__A4AE64D81A59A9EE");

            entity.Property(e => e.CustomerId).ValueGeneratedNever();
            entity.Property(e => e.AdditionalSigh).HasMaxLength(10);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Street).HasMaxLength(200);
            entity.Property(e => e.StreetType).HasMaxLength(100);

            entity.HasOne(d => d.Customer).WithOne(p => p.Address)
                .HasForeignKey<Address>(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(250);
        });

        modelBuilder.Entity<ContactInfo>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => e.CustomerId, "UQ__ContactI__A4AE64D9A36F54CC").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(20);
            entity.Property(e => e.PhoneNumber1).HasMaxLength(20);
            entity.Property(e => e.PhoneNumber2).HasMaxLength(20);
            entity.Property(e => e.Site).HasMaxLength(1000);

            entity.HasOne(d => d.Customer).WithOne()
                .HasForeignKey<ContactInfo>(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ContactIn__Custo__05D8E0BE");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("First Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("Last Name");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC076C709A35");

            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC07551E5A0D");

            entity.Property(e => e.FirstName).HasMaxLength(150);
            entity.Property(e => e.LastName).HasMaxLength(150);
            entity.Property(e => e.Position).HasMaxLength(200);
            entity.Property(e => e.Sallary).HasColumnType("money");

            entity.HasOne(d => d.Boss).WithMany(p => p.InverseBoss)
                .HasForeignKey(d => d.BossId)
                .HasConstraintName("FK_Boss_Id");

            entity.HasMany(d => d.Departments).WithMany(p => p.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    "EmploeeDepartment",
                    r => r.HasOne<Department>().WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__EmploeeDe__Depar__2DE6D218"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__EmploeeDe__Emplo__2CF2ADDF"),
                    j =>
                    {
                        j.HasKey("EmployeeId", "DepartmentId").HasName("PK_EmployeeDepartment_Id");
                        j.ToTable("EmploeeDepartment");
                    });
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("First Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("Last Name");
            entity.Property(e => e.Position).HasMaxLength(150);
            entity.Property(e => e.Salary).HasColumnType("money");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NewOrder__3214EC072E04BF8F");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NewOrders__Custo__1DB06A4F");

            entity.HasOne(d => d.Manager).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NewOrders__Manag__1EA48E88");
        });

        modelBuilder.Entity<OrderPosition>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.PositionNumber }).HasName("PK_OrderId_PositionNumber");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderPositions)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderPosi__Order__208CD6FA");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderPositions)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderPosi__Produ__2180FB33");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Price)
                .HasDefaultValueSql("((0))")
                .HasColumnType("money");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_Brands");
        });

        modelBuilder.Entity<ProductInventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductI__3214EC07BF23003E");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductInventories)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductIn__Produ__17036CC0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
