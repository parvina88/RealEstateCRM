namespace RealEstate.Client.Services.Auth
{
    public record AccountSignInResponse
    {
        public bool Success { get; set; }
        public required  string Token { get; set; }
    }
}
