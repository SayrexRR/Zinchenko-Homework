using RelationshipEFCore.Models;

namespace RelationshipEFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new PersonalContext();

            #region Initialize
            if (!context.Departments.Any())
            {
                var departments = new List<Department>
            {
                new Department() { Name = "Marketing Department" },
                new Department() { Name = "Finance Department" },
                new Department() { Name = "Legal Department" }
            };

                context.Departments.AddRange(departments);

                var persons = new List<Person>
            {
                new Person() { FirstName = "Emily", LastName = "Johnson", DateOfBirth = new DateTime(1995, 10, 21) },
                new Person() { FirstName = "James", LastName = "Wilson", DateOfBirth = new DateTime(1996, 5, 14) },
                new Person() { FirstName = "Michael", LastName = "Jackson", DateOfBirth = new DateTime(2000, 7, 5) },
                new Person() { FirstName = "Sarah", LastName = "Smith", DateOfBirth = new DateTime(1998, 10, 3) },
                new Person() { FirstName = "Jessica", LastName = "Williams", DateOfBirth = new DateTime(2002, 3, 11) },
            };

                context.Persons.AddRange(persons);

                var employees = new List<Employee>
            {
                new Employee() { FirstName = "Robert", LastName = "Davis", DateOfBirth = new DateTime(1997, 9, 15), Salary = 11000, Department = departments[0] },
                new Employee() { FirstName = "William", LastName = "Thomas", DateOfBirth = new DateTime(1995, 8, 21), Salary = 10500, Department = departments[2] },
                new Employee() { FirstName = "Olivia", LastName = "Brown", DateOfBirth = new DateTime(2000, 2, 11), Salary = 11000, Department = departments[1] },
                new Employee() { FirstName = "John", LastName = "Johnson", DateOfBirth = new DateTime(2000, 6, 20), Salary = 11200, Department = departments[0] },
                new Employee() { FirstName = "Emma", LastName = "Davis", DateOfBirth = new DateTime(1996, 12, 3), Salary = 10800, Department = departments[2] },
            };

                context.Employees.AddRange(employees);

                var managers = new List<Manager>
            {
                new Manager() { FirstName = "Mia", LastName = "Jones", DateOfBirth= new DateTime(2000, 4, 4), Salary = 14300, Department = departments[0], Bonus = 2000, IsDepartmentHead = true },
                new Manager() { FirstName = "Sophia", LastName = "Miller", DateOfBirth= new DateTime(1999, 12, 15), Salary = 15700, Department = departments[1], Bonus = 0, IsDepartmentHead = false },
                new Manager() { FirstName = "Benjamin", LastName = "Smith", DateOfBirth= new DateTime(1998, 8, 11), Salary = 15500, Department = departments[1], Bonus = 500, IsDepartmentHead = true },
                new Manager() { FirstName = "Samuel", LastName = "Miller", DateOfBirth= new DateTime(1998, 3, 8), Salary = 17000, Department = departments[2], Bonus = 300, IsDepartmentHead = true },
                new Manager() { FirstName = "Alexander", LastName = "Clark", DateOfBirth= new DateTime(1995, 10, 12), Salary = 14600, Department = departments[0], Bonus = 0, IsDepartmentHead = false },
            };

                context.Managers.AddRange(managers);

                context.SaveChanges();
            }
            #endregion


            var employes = Repository.GetEmployeesByDepartmentId(1);

            foreach (var employe in employes)
            {
                Console.WriteLine($"{employe.FirstName} {employe.Department.Name} {employe.Salary}");
            }
            Console.WriteLine(new string('-', 50));

            var employee = Repository.GetEmployeeById(3);

            Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}, Salary: {employee.Salary}, Department: {employee.Department.Name}");
            Console.WriteLine(new string('-', 50));

            var personsBorn = Repository.GetPersonsBornAfter(new DateTime(2000, 1, 1));

            foreach (var person in personsBorn)
            {
                if (person is Employee empl)
                {
                    Console.WriteLine($"Name: {empl.FirstName} {empl.LastName}, Salary: {empl.Salary}, Department: {empl.Department.Name}");
                }
                else
                {
                    Console.WriteLine($"Name: {person.FirstName} {person.LastName}");
                }
            }
        }
    }
}