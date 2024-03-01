namespace RealEstate.Client.Services.HttpClients;

public interface IHttpClientService
{
    Task<ApiResponse<T>> PostJsonAsync<T>(string url, object request);
    Task<ApiResponse<T>> GetJsonAsync<T>(string url, object request);
    Task<ApiResponse<T>> PutJsonAsync<T>(string url, object request);
    Task<ApiResponse> DeleteAsync(string url);
}
