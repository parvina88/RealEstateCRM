namespace RealEstate.Contract.Auth;

public record UserSession(string? Id, string? Name, string? Email, string? Role);