using RealEstate.Contract.Apartment;
using RealEstate.Contract.Building;

namespace RealEstate.Client.Services.Building
{
    public interface IBuildingService
    {
        Task<ApiResponse<List<SingleBuildingResponse>>> GetAllAsync(GetBuildingsQuery query);

        Task<ApiResponse<SingleBuildingResponse>> CreateAsync(CreateBuildingRequest request);

        Task<ApiResponse<SingleBuildingResponse>> UpdateAsync(UpdateBuildingRequest request);

        Task<ApiResponse> DeleteAsync(DeleteBuildingRequest request);
    }
}
