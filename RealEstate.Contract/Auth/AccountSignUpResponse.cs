namespace RealEstate.Contract.Auth;

public record AccountSignUpResponse
{
    public bool Success { get; set; }
    public required string Message { get; set; }
    public required string Token { get; set; }
}
