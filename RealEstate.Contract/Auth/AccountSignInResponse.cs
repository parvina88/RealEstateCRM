namespace RealEstate.Contract.Auth
{
    public record AccountSignInResponse
    {
        public bool Success { get; set; }
        public string? Error { get; set; }
        public string? Token { get; set; }
    }
}
