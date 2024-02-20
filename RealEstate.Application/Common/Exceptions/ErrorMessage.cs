namespace RealEstate.Application.Common.Exceptions;

public record ErrorMessage
{
    public string PropertyName { get; init; }
    public string Message { get; init; }
}
