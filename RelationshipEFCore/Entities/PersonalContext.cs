using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelationshipEFCore.DataLayer.Entities;

namespace RelationshipEFCore.DataLayer.Entities
{
    public class PersonalContext : DbContext
    {
        public PersonalContext()
        {
            Database.EnsureCreated();

            if (!Departments.Any())
            {
                var departments = new List<Department>
                {
                    new Department() { Name = "Marketing Department" },
                    new Department() { Name = "Finance Department" },
                    new Department() { Name = "Legal Department" }
                };

                Departments.AddRange(departments);

                var persons = new List<Person>
                {
                    new Person() { FirstName = "Emily", LastName = "Johnson", DateOfBirth = new DateTime(1995, 10, 21) },
                    new Person() { FirstName = "James", LastName = "Wilson", DateOfBirth = new DateTime(1996, 5, 14) },
                    new Person() { FirstName = "Michael", LastName = "Jackson", DateOfBirth = new DateTime(2000, 7, 5) },
                    new Person() { FirstName = "Sarah", LastName = "Smith", DateOfBirth = new DateTime(1998, 10, 3) },
                    new Person() { FirstName = "Jessica", LastName = "Williams", DateOfBirth = new DateTime(2002, 3, 11) },
                };

                Persons.AddRange(persons);

                var employees = new List<Employee>
                {
                    new Employee() { FirstName = "Robert", LastName = "Davis", DateOfBirth = new DateTime(1997, 9, 15), Salary = 11000, Department = departments[0] },
                    new Employee() { FirstName = "William", LastName = "Thomas", DateOfBirth = new DateTime(1995, 8, 21), Salary = 10500, Department = departments[2] },
                    new Employee() { FirstName = "Olivia", LastName = "Brown", DateOfBirth = new DateTime(2000, 2, 11), Salary = 11000, Department = departments[1] },
                    new Employee() { FirstName = "John", LastName = "Johnson", DateOfBirth = new DateTime(2000, 6, 20), Salary = 11200, Department = departments[0] },
                    new Employee() { FirstName = "Emma", LastName = "Davis", DateOfBirth = new DateTime(1996, 12, 3), Salary = 10800, Department = departments[2] },
                };

                Employees.AddRange(employees);

                var managers = new List<Manager>
                {
                    new Manager() { FirstName = "Mia", LastName = "Jones", DateOfBirth= new DateTime(2000, 4, 4), Salary = 14300, Department = departments[0], Bonus = 2000, IsDepartmentHead = true },
                    new Manager() { FirstName = "Sophia", LastName = "Miller", DateOfBirth= new DateTime(1999, 12, 15), Salary = 15700, Department = departments[1], Bonus = 0, IsDepartmentHead = false },
                    new Manager() { FirstName = "Benjamin", LastName = "Smith", DateOfBirth= new DateTime(1998, 8, 11), Salary = 15500, Department = departments[1], Bonus = 500, IsDepartmentHead = true },
                    new Manager() { FirstName = "Samuel", LastName = "Miller", DateOfBirth= new DateTime(1998, 3, 8), Salary = 17000, Department = departments[2], Bonus = 300, IsDepartmentHead = true },
                    new Manager() { FirstName = "Alexander", LastName = "Clark", DateOfBirth= new DateTime(1995, 10, 12), Salary = 14600, Department = departments[0], Bonus = 0, IsDepartmentHead = false },
                };

                Managers.AddRange(managers);

                SaveChanges();
            }
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

            modelBuilder.Entity<Employee>()
                .HasOne(m => m.Department)
                .WithMany(d => d.Employees)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
