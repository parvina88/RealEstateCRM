namespace RealEstate.Application.Entities;

public class Apartment
{
    public Guid Id { get; set; }
    public string Number { get; set; }
    public int NumberOfRooms { get; set; }
    public Guid ApartmentTypeId { get; set; }
}