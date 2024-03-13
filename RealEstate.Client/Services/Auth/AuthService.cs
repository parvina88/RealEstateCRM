using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using RealEstate.Client.Services.HttpClients;
using RealEstate.Contract.Auth;
using System.Text.Json;

namespace RealEstate.Client.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly IHttpClientService _httpClient;
        private readonly ILocalStorageService _localStorageService;
        private readonly IConfiguration _configuration;

        public AuthService(AuthenticationStateProvider authenticationStateProvider,
            IHttpClientService httpClient, ILocalStorageService localStorageService, IConfiguration configuration)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _httpClient = httpClient;
            _localStorageService = localStorageService;
            _configuration = configuration;
        }

        public Task<bool> CheckAuthenticatedAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<AccountSignInResponse>> LoginAsync(AccountSignInRequest accountSignInRequest)
        {
            try
            {
                var loginAsJson = JsonSerializer.Serialize(accountSignInRequest);
                var response = await _httpClient.PostJsonAsync<AccountSignInResponse>($"{_configuration["ApiUrl"]}/identity/login", loginAsJson);

                if (response.Success)
                {
                    await _localStorageService.SetItemAsync(IAuthService.TokenLocalStorageKey, response.Result.Token);
                    await _authenticationStateProvider.GetAuthenticationStateAsync();
                }
                else if (response.HttpStatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    response.Error = "Username or password is incorrect!";
                }

                return response;
            }
            catch (Exception ex)
            {
                return ApiResponse<AccountSignInResponse>.BuildFailed($"An unexpected error occurred. Please contact customer support. {ex.Message}");
            }
        }

        public async Task LogoutAsync()
        {
            await _localStorageService.RemoveItemAsync(IAuthService.TokenLocalStorageKey);
            await _authenticationStateProvider.GetAuthenticationStateAsync();
        }

        public async Task<ApiResponse<AccountSignUpResponse>> RegisterAsync(AccountSignUpRequest accountSignUpRequest)
        {
            try
            {
                var tokenResponse = await _httpClient.PostJsonAsync<AccountSignUpResponse>($"{_configuration["ApiUrl"]}/identity/register", accountSignUpRequest);
                if (tokenResponse.Success)
                {
                    await _localStorageService.SetItemAsync(IAuthService.TokenLocalStorageKey, tokenResponse.Result.Token);
                    await _authenticationStateProvider.GetAuthenticationStateAsync();
                }
                else if (tokenResponse.Result != null)
                {
                    tokenResponse.Error = tokenResponse.Result.Message;
                }

                return tokenResponse;
            }
            catch (Exception ex)
            {
                return ApiResponse<AccountSignUpResponse>.BuildFailed($"An unexpected error occurred. Please contact customer support. {ex.Message}");
            }
        }
    }
}
