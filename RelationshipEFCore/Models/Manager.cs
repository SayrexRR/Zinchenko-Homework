using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationshipEFCore.Models
{
    public class Manager : Employee
    {
        public decimal? Bonus { get; set; }
        public bool? IsDepartmentHead { get; set; }
    }
}
