namespace RealEstate.Contract.Apartment;

public record ApartmentsResponse() 
{
    public IEnumerable<SingleApartmentResponse> Items { get; set; } = Enumerable.Empty<SingleApartmentResponse>();
}