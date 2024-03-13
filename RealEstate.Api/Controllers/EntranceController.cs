using Microsoft.AspNetCore.Mvc;
using RealEstate.Contract.Entrance;

namespace RealEstate.Api.Controllers
{
    public class EntranceController : ApiControllerBase
    {
        [HttpPost(ApiEndpoints.Entrance.Create)]
        public async Task<IActionResult> Create([FromBody] CreateEntranceRequest request, CancellationToken token)
        {
            var response = await Sender.Send(request, token);
            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        [HttpGet(ApiEndpoints.Entrance.GetAll)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var request = new GetEntrancesQuery();
            EntrancesResponse response = await Sender.Send(request, token);
            
            return Ok(response);
        }

        [HttpGet(ApiEndpoints.Entrance.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken token)
        {
            var request = new GetSingleEntranceQuery(id);
            SingleEntranceResponse response = await Sender.Send(request, token);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpGet(ApiEndpoints.Entrance.GetAllByBuilding)]
        public async Task<IActionResult> GetAllByBuilding([FromRoute] Guid id, CancellationToken token)
        {
            var request = new GetEntrancesByBuildingQuery(id);
            EntrancesResponse response = await Sender.Send(request, token);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpPut(ApiEndpoints.Entrance.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateEntranceRequest request, CancellationToken token)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            request.Id = id;
            var response = await Sender.Send(request, token);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpDelete(ApiEndpoints.Entrance.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            var request = new DeleteEntranceRequest(id);
            bool response = await Sender.Send(request, token);

            if (!response)
                return NotFound();

            return Ok(response);
        }
    }
}
