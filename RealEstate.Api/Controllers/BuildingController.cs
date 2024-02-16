using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Services;
using RealEstate.Contract.Building;
using RealEstate.Application.Mapping;

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

        [HttpGet(ApiEndpoints.Building.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var buildings = await _service.GetAllAsync();
            var response = buildings.MapToResponse();
            return Ok(response);
        }

        [HttpPut(ApiEndpoints.Building.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateBuildingRequest request, CancellationToken token = default)
        {
            var building = request.MapToBuilding(id);
            var updatedBuilding = await _service.UpdateAsync(building);

            if (!updatedBuilding)
                return NotFound();

            var response = building.MapToResponse();

            return Ok(response);
        }

        [HttpDelete(ApiEndpoints.Building.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedBuilding = await _service.DeleteAsync(id);

            if(!deletedBuilding)
                return NotFound();

            return Ok();
        }
    }
}
