using RealEstate.Domain.Enums;

namespace RealEstate.Domain.Entities;

public class Employee
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public Guid DepartmentId { get; set; }
    public virtual Department Department { get; set; }

    public Position Position { get; set; }

    public virtual ICollection<Deal> Deals { get; set; }
}