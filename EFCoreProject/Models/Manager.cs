using System;
using System.Collections.Generic;

namespace EFCoreProject.Models;

public partial class Manager
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Position { get; set; } = null!;

    public decimal? Salary { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
