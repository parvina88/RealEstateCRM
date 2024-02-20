namespace RealEstate.Application.Common.Exceptions;

public record ErrorResponse
{
    public List<ErrorMessage> Errors { get; init; }
}
