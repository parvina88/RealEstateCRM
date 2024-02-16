namespace RealEstate.Domain.Entities;

public class Document
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string FilePath { get; set; }
    public string OriginalFileName { get; set; }

    public Guid? ApartmentId { get; set; }
    public Apartment Apartment { get; set; }

    public Guid? EntranceId { get; set; }
    public Entrance Entrance { get; set; }
}