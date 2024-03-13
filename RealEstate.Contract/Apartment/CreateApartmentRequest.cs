namespace RealEstate.Contract.Apartment;

public class CreateApartmentRequest : IRequest<SingleApartmentResponse>
{
    public string Number { get; set; }
    public int Floor { get; set; }
    public int NumberOfRooms { get; set; }
    public double TotalArea { get; set; }
    public double LivingArea { get; set; }
    public decimal PricePerSquare { get; set; }
    public ApartmentType Type { get; set; }
    public ApartmentStatus Status { get; set; } = ApartmentStatus.Available;
    public Guid EntranceId { get; set; }
}
