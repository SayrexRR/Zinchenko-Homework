using System;
using System.Collections.Generic;

namespace EFCore.Models;

public partial class Employee
{
    public int Id { get; set; }

    public int? BossId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string Position { get; set; } = null!;

    public decimal Sallary { get; set; }

    public int? InfoId { get; set; }

    public virtual Employee? Boss { get; set; }

    public virtual ICollection<Employee> InverseBoss { get; set; } = new List<Employee>();

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}
