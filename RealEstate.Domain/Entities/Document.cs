namespace RealEstate.Domain.Entities;

public class Document
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string FilePath { get; set; }
    public string OriginalFileName { get; set; }
}