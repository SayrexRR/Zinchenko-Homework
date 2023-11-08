using System;
using System.Collections.Generic;

namespace EFCore.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int CustomerId { get; set; }

    public int ManagerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Manager Manager { get; set; } = null!;

    public virtual ICollection<OrderPosition> OrderPositions { get; set; } = new List<OrderPosition>();
}
