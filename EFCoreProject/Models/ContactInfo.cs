using System;
using System.Collections.Generic;

namespace EFCoreProject.Models;

public partial class ContactInfo
{
    public int CustomerId { get; set; }

    public string? PhoneNumber1 { get; set; }

    public string? PhoneNumber2 { get; set; }

    public string? Email { get; set; }

    public string? Site { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
