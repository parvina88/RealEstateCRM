namespace RealEstate.Domain.Entities;

public class Entrance // Подъезд
{
    public Guid Id { get; set; }
    public string Number { get; set; }
    public int NumberOfFloors { get; set; }
    public int NumberOfApartmentsPerFloor { get; set; }
    public double CeilingHeight { get; set; } // Высота потолков (в метрах)
    public bool HasLift { get; set; }

    public Guid BuildingId { get; set; }
    public virtual Building Building { get; set; }

    public virtual ICollection<Apartment> Apartments { get; set; }
    public virtual ICollection<Document> AttachedDocuments { get; set; }

}