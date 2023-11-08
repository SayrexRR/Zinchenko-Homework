using System;
using System.Collections.Generic;

namespace EFCore.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal? Price { get; set; }

    public string? Description { get; set; }

    public int? SupplierId { get; set; }

    public virtual ICollection<OrderPosition> OrderPositions { get; set; } = new List<OrderPosition>();

    public virtual ICollection<ProductInventory> ProductInventories { get; set; } = new List<ProductInventory>();

    public virtual Brand? Supplier { get; set; }
}
