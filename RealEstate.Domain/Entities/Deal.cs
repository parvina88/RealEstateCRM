using RealEstate.Domain.Enums;

namespace RealEstate.Domain.Entities;

public class Deal
{
    public Guid Id { get; set; }
    public Apartment Apartment { get; set; }
    public Customer Customer { get; set; }
    public Employee Employee { get; set; }
    public DealStatus Status { get; set; }
    public DateTime Date { get; set; }
    public string Comment { get; set; }
}