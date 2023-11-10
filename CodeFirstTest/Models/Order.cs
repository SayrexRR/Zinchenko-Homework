using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTest.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int EmployeeId { get; set; }
        public int ClientId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
