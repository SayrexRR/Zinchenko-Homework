using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationshipEFCore.BussinessLayer.Models
{
    public class Employee : Person
    {
        public decimal Salary { get; set; }

        public Department Department { get; set; }
    }
}
