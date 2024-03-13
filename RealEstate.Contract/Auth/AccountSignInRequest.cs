using System.ComponentModel.DataAnnotations;

namespace RealEstate.Contract.Auth;

public record AccountSignInRequest
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}
