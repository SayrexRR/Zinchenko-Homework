using RelationshipEFCore.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationshipEFCore.DataLayer
{
    public static class Repository
    {
        public static List<Employee> GetEmployeesByDepartmentId(int id)
        {
            using var context = new PersonalContext();

            var department = context.Departments.Single(d => d.Id == id);
            
            var employees = context.Entry(department)
                .Collection(d => d.Employees)
                .Query()
                .ToList();

            return employees;
        }

        public static Employee GetEmployeeById(int id)
        {
            using var context = new PersonalContext();

            var employee = context.Employees.Single(e => e.Id == id);

            context.Entry(employee)
                .Reference(e => e.Department)
                .Load();

            return employee;
        }

        public static List<Person> GetPersonsBornAfter(DateTime date)
        {
            using var context = new PersonalContext();

            var persons = context.Persons.Where(p => p.DateOfBirth > date).ToList();

            foreach (var person in persons)
            {
                if (context.Employees.Any(e => e.Id == person.Id))
                {
                    context.Entry((Employee) person).Reference(e => e.Department).Load();
                }
            }

            return persons;
        }
    }
}
