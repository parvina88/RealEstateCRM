using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.Mapping;
using RealEstate.Api.Services;
using RealEstate.Contract.Building;

namespace RealEstate.Api.Controllers
{
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService _service;

        [HttpPost(ApiEndPoints.Building.Create)]
        public async Task<IActionResult> Create([FromBody] CreateBuildingRequest request, CancellationToken token)
        {
            var building = request.MapToBuilding();
            await _service.CreateAsync(building, token);
            return Ok();
        }
    }
}
