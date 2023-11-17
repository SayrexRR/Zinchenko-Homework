using RelationshipEFCore.BussinessLayer;

namespace RelationshipEFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintEmployeesByDepartment(2);

            PrintEmployeeInfo(6);

            PrintPersonsBornAfter(new DateTime(1999, 1, 1));
        }

        public static void PrintEmployeesByDepartment(int id)
        {
            var employes = PersonService.GetEmployeesByDepartmentId(id);

            foreach (var employe in employes)
            {
                Console.WriteLine($"{employe.FirstName} {employe.Department.Name} {employe.Salary}");
            }
            Console.WriteLine(new string('-', 50));
        }

        public static void PrintEmployeeInfo(int id)
        {
            var employee = PersonService.GetEmployeeById(id);

            Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}, Salary: {employee.Salary}, Department: {employee.Department.Name}");
            Console.WriteLine(new string('-', 50));
        }

        public static void PrintPersonsBornAfter(DateTime date)
        {
            var personsBorn = PersonService.GetPersonsBornAfter(date);

            foreach (var person in personsBorn)
            {
                Console.WriteLine($"Name: {person.FirstName} {person.LastName}");
            }
        }
    }
}