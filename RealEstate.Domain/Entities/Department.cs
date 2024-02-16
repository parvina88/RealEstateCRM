﻿namespace RealEstate.Domain.Entities;

public class Department
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Employee>? Employees { get; set; }
}