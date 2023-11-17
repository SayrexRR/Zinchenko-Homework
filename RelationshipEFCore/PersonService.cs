using RelationshipEFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationshipEFCore
{
    public static class PersonService
    {
        public static List<Employee> GetEmployeesByDepartmentId(int id)
        {
            return Repository.GetEmployeesByDepartmentId(id);
        }

        public static Employee GetEmployeeById(int id)
        {
            return Repository.GetEmployeeById(id);
        }

        public static List<Person> GetPersonsBornAfter(DateTime date)
        {
            return Repository.GetPersonsBornAfter(date);
        }
    }
}
