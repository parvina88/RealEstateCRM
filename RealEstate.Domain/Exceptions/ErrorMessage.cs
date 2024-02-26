namespace RealEstate.Domain.Exceptions;

public record ErrorMessage
{
    public string PropertyName { get; init; }
    public string Message { get; init; }
}
