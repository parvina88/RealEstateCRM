using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Services;
using RealEstate.Contract.Building;
using RealEstate.Application.Mapping;
using RealEstate.Application.Buildings.Queries.GetBuildingDetails;

namespace RealEstate.Api.Controllers
{
    [ApiController]
    public class BuildingController : ApiControllerBase
    {
        private readonly IBuildingService _service;

        public BuildingController(IBuildingService service)
        {
            _service = service;
        }

        [HttpPost(ApiEndpoints.Building.Create)]
        public async Task<IActionResult> Create([FromBody] CreateBuildingRequest request, CancellationToken token)
        {
            var response = await Sender.Send(request);
            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        [HttpGet(ApiEndpoints.Building.Get)]
        public async Task<SingleBuildingResponse> Get([FromRoute] Guid id, CancellationToken token)
        {
            var query = new GetSingleBuildingQuery()
            {
                BuildingId = id
            };

            return await Sender.Send(query, token);
        }

        [HttpGet(ApiEndpoints.Building.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var request = new GetBuildingsQuery();
            var response =  await Sender.Send(request);

            return Ok(response);
        }

        [HttpPut(ApiEndpoints.Building.Update)]
        public async Task<SingleBuildingResponse> Update([FromRoute] Guid id, [FromBody] UpdateBuildingRequest request, CancellationToken token = default)
        {
            request.Id = id;
            return await Sender.Send(request);
        }

        [HttpDelete(ApiEndpoints.Building.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var request = new DeleteBuildingRequest(id);
            var response = await Sender.Send(request);

            if(!response)
                return NotFound();

            return Ok();
        }
    }
}
