using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationshipEFCore.DataLayer.Entities
{
    public class Employee : Person
    {
        public decimal Salary { get; set; }

        public virtual Department Department { get; set; }
    }
}
