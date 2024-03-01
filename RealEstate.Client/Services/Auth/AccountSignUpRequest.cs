using System.ComponentModel.DataAnnotations;

namespace RealEstate.Client.Services.Auth;

public record AccountSignUpRequest
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
}
