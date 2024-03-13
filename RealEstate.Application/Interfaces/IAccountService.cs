using RealEstate.Contract.Auth;

namespace RealEstate.Application.Interfaces;

public interface IAccountService
{
    Task<AccountSignInResponse> SignInAsync(AccountSignInRequest request);
    Task<AccountSignUpResponse> SignUpAsync(AccountSignUpRequest request);
}
