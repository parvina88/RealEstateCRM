using RealEstate.Domain.Enums;

namespace RealEstate.Domain.Entities;

public class Apartment
{
    public Guid Id { get; set; }
    public required string Number { get; set; }
    public int Floor { get; set; }
    public required int NumberOfRooms { get; set; }
    public required double TotalArea { get; set; }
    public double LivingArea { get; set; }
    public decimal PricePerSquare { get; set; }
    public ApartmentType Type { get; set; }
    public ApartmentStatus Status { get; set; }
    
    public Guid EntranceId { get; set; }
    public virtual Entrance Entrance { get; set; }
    
    public Guid SchemeId { get; set; }
    public virtual Document Scheme { get; set; }
}