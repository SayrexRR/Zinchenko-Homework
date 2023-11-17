using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTest.Models
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int Position { get; set; }
        public int Quantity { get; set; }
        public int BookId { get; set; }

        public virtual Book Book {  get; set; } 
        public virtual Order Order { get; set; }
    }
}
