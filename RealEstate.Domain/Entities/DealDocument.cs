namespace RealEstate.Domain.Entities;

public class DealDocument
{
    public Guid DealId { get; set; }
    public virtual Deal Deal { get; set; }

    public Guid DocumentId { get; set; }
    public virtual Document Document { get; set; }
}
