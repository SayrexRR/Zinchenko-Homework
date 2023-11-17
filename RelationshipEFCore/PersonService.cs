using RelationshipEFCore.BussinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelationshipEFCore.DataLayer;

namespace RelationshipEFCore.BussinessLayer
{
    public static class PersonService
    {
        public static List<Employee> GetEmployeesByDepartmentId(int id)
        {
            var employees = Repository.GetEmployeesByDepartmentId(id);

            return employees.Select(e => new Employee
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                DateOfBirth = e.DateOfBirth,
                Salary = e.Salary,
                Department = new Department() { Name = e?.Department?.Name }
            }).ToList();
        }

        public static Employee GetEmployeeById(int id)
        {
            var employee = Repository.GetEmployeeById(id);

            return new Employee
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DateOfBirth = employee.DateOfBirth,
                Salary = employee.Salary,
                Department = new Department() { Name = employee?.Department?.Name }
            };
        }

        public static List<Person> GetPersonsBornAfter(DateTime date)
        {
            var persons = Repository.GetPersonsBornAfter(date);

            return persons.Select(p => new Person
            {
                FirstName = p.FirstName,
                LastName = p.LastName,
                DateOfBirth = p.DateOfBirth
            }).ToList();
        }
    }
}
