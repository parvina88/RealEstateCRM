namespace RealEstate.Domain.Entities;

public class Employee
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public Guid DepartmentId { get; set; }
    public Guid PositionId { get; set; }
}