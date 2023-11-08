using System;
using System.Collections.Generic;

namespace EFCore.Models;

public partial class OrderPosition
{
    public int OrderId { get; set; }

    public short PositionNumber { get; set; }

    public int ProductId { get; set; }

    public int Qty { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
