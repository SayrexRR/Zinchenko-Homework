using System;
using System.Collections.Generic;

namespace EFCoreProject.Models;

public partial class ProductInventory
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int WarehouseId { get; set; }

    public int? TotalQty { get; set; }

    public int? ScheduledQty { get; set; }

    public virtual Product Product { get; set; } = null!;
}
