using RealEstate.Client.Services.HttpClients;
using RealEstate.Contract.Building;

namespace RealEstate.Client.Services.Building;

public class BuildingService : IBuildingService
{
    private readonly IHttpClientService _httpClient;
    private readonly IConfiguration _configuration;

    public BuildingService(IHttpClientService httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<ApiResponse<SingleBuildingResponse>> CreateAsync(CreateBuildingRequest request)
    {
        return await _httpClient.PostJsonAsync<SingleBuildingResponse>($"{_configuration["ApiUrl"]}/api/building", request);
    }

    public async Task<ApiResponse> DeleteAsync(DeleteBuildingRequest request)
    {
        return await _httpClient.DeleteAsync($"{_configuration["ApiUrl"]}/api/building/{request.Id}");
    }

    public async Task<ApiResponse<BuildingsResponse>> GetAllAsync(GetBuildingsQuery request)
    {
        return await _httpClient.GetJsonAsync<BuildingsResponse>($"{_configuration["ApiUrl"]}/Building/api/buildings", request);
    }

    public async Task<ApiResponse<SingleBuildingResponse>> UpdateAsync(UpdateBuildingRequest request)
    {
        return await _httpClient.PutJsonAsync<SingleBuildingResponse>($"{_configuration["ApiUrl"]}/api/building", request);
    }
}
