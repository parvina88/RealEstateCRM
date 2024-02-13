namespace RealEstate.Domain.Entities;

public class Customer
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string PhoneNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }
}