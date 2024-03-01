using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Contract.Building;

namespace RealEstate.Api.Controllers
{
    [ApiController]
    public class BuildingController : ApiControllerBase
    {
        [HttpPost(ApiEndpoints.Building.Create)]
        public async Task<IActionResult> Create([FromBody] CreateBuildingRequest request, CancellationToken token)
        {
            var response = await Sender.Send(request, token);
            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        [Authorize]
        [HttpGet(ApiEndpoints.Building.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken token)
        {
            var query = new GetSingleBuildingQuery()
            {
                BuildingId = id
            };

            var response = await Sender.Send(query, token);

            return response == null ? NotFound() : Ok(response);
        }

        [Authorize]
        [HttpGet(ApiEndpoints.Building.GetAll)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var request = new GetBuildingsQuery();
            var response =  await Sender.Send(request, token);

            return Ok(response);
        }

        [HttpPut(ApiEndpoints.Building.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateBuildingRequest request, CancellationToken token)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            request.Id = id;
            var response = await Sender.Send(request, token);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpDelete(ApiEndpoints.Building.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            var request = new DeleteBuildingRequest(id);
            var response = await Sender.Send(request, token);

            return response ? Ok() : NotFound($"Building with ID {id} not found.");
        }
    }
}
