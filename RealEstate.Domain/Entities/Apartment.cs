using RealEstate.Domain.Enums;

namespace RealEstate.Domain.Entities;

public class Apartment
{
    public Guid Id { get; set; }
    public string Number { get; set; }
    public int Floor { get; set; }
    public int NumberOfRooms { get; set; }
    public double TotalArea { get; set; }
    public double LivingArea { get; set; }
    public decimal PricePerSquare { get; set; }
    public ApartmentType Type { get; set; }
    public ApartmentStatus Status { get; set; }

    public Guid EntranceId { get; set; }
    public virtual Entrance Entrance { get; set; }

    public virtual ICollection<Document>? AttachedDocuments { get; set; }
}