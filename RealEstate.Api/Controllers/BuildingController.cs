using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.Mapping;
using RealEstate.Application.Services;
using RealEstate.Contract.Building;

namespace RealEstate.Api.Controllers
{
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService _service;

        public BuildingController(IBuildingService service)
        {
            _service = service;
        }

        [HttpPost(ApiEndpoints.Building.Create)]
        public async Task<IActionResult> Create([FromBody] CreateBuildingRequest request, CancellationToken token)
        {
            var building = request.MapToBuilding();
            var response = await _service.CreateAsync(building, token);

            if (response == false)
            {
                return StatusCode(500, "Failed to create building");
            }

            return CreatedAtAction(nameof(Get), new { id = building.Id }, building);
        }

        [HttpGet(ApiEndpoints.Building.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken token)
        {
            var building = await _service.GetAsync(id);

            if (building is null)
                return NotFound();

            var response = building.MapToResponse();
            return Ok(response);
        }

        [HttpPut(ApiEndpoints.Building.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateBuildingRequest request, CancellationToken token = default)
        {

        }
    }
}
