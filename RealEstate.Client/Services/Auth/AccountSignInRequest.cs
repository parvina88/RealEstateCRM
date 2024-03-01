using System.ComponentModel.DataAnnotations;

namespace RealEstate.Client.Services.Auth;

public record AccountSignInRequest
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
}
