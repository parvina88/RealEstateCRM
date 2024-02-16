using RealEstate.Domain.Enums;

namespace RealEstate.Domain.Entities;

public class Deal
{
    public Guid Id { get; set; }

    public Guid ApartmentId { get; set; }
    public virtual Apartment Apartment { get; set; }

    public Guid CustomerId { get; set; }
    public virtual Customer Customer { get; set; }

    public Guid EmployeeId { get; set; }
    public virtual Employee Employee { get; set; }

    public DealStatus Status { get; set; }

    public DateTime Date { get; set; }

    public string Comment { get; set; }

    public virtual ICollection<DealDocument> DealDocuments { get; set; }

}