using Blazored.LocalStorage;
using RealEstate.Client.Services.Auth;
using System.Net.Http.Headers;

namespace RealEstate.Client.Services.HttpClients
{
    public class HttpClientService : IHttpClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILocalStorageService _localStorageService;

        public HttpClientService(IHttpClientFactory httpClientFactory, ILocalStorageService localStorageService)
        {
            _httpClientFactory = httpClientFactory;
            _localStorageService = localStorageService;
        }

        public Task<ApiResponse> DeleteAsync(string url)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<T>> GetJsonAsync<T>(string url, object content)
        {
            try
            {
                using var _httpClient = await CreateHttpClient();
                var response = await _httpClient.GetFromJsonAsync<T>(url, content);
                return ApiResponse<T>.BuildSuccess(response);
            }
            catch (HttpRequestException ex)
            {

                return ApiResponse<T>.BuildFailed($"Server is not responding. {ex.Message}", ex.StatusCode);
            }

        }

        public Task<ApiResponse<T>> PostJsonAsync<T>(string url, object request)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<T>> PutJsonAsync<T>(string url, object request)
        {
            throw new NotImplementedException();
        }

        private async Task<HttpClient> CreateHttpClient()
        {
            var _httpClient = _httpClientFactory.CreateClient("We");
            string? token = await _localStorageService.GetItemAsync<string>(IAuthService.TokenLocalStorageKey);

            if (!string.IsNullOrEmpty(token))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return _httpClient;
        }
    }
}
