using RealEstate.Contract.Auth;

namespace RealEstate.Client.Services.Auth;

public interface IAuthService
{
    public const string TokenLocalStorageKey = "TokenLocalStorageKey";
    Task<ApiResponse<AccountSignInResponse>> LoginAsync(AccountSignInRequest accountSignInRequest);
    Task<ApiResponse<AccountSignUpResponse>> RegisterAsync(AccountSignUpRequest accountSignInRequest);
    Task LogoutAsync();
    public Task<bool> CheckAuthenticatedAsync();
}
