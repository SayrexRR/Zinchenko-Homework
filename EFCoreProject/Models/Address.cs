using System;
using System.Collections.Generic;

namespace EFCoreProject.Models;

public partial class Address
{
    public int CustomerId { get; set; }

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string StreetType { get; set; } = null!;

    public short Number { get; set; }

    public string? AdditionalSigh { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
