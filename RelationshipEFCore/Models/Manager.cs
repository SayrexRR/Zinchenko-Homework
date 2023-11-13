using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationshipEFCore.Models
{
    public class Manager : Employee
    {
        public virtual Department Department { get; set; }
    }
}
