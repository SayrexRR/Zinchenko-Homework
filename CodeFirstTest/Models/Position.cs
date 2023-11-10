using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTest.Models
{
    public class Position
    {
        public int EmployeeId { get; set; }
        public string Name {  get; set; }

        public virtual Employee Employee { get; set; }
    }
}
