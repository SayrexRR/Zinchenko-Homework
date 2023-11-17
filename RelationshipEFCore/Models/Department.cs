using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationshipEFCore.BussinessLayer.Models
{
    public class Department
    {
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
