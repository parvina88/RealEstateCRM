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
            var response = await Sender.Send(request);
            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        [HttpGet(ApiEndpoints.Building.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken token)
        {
            var query = new GetSingleBuildingQuery()
            {
                BuildingId = id
            };

            var response = await Sender.Send(query, token);

            if (response == null)
                return NotFound();

            return Ok(response);
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

            return Ok(response);
        }
    }
}
