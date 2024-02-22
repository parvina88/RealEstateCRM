using Azure;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Contract.Entrance;

namespace RealEstate.Api.Controllers
{
    public class EntranceController : ApiControllerBase
    {
        [HttpPost(ApiEndpoints.Entrance.Create)]
        public async Task<IActionResult> Create([FromBody] CreateEntranceRequest request)
        {
            var response = await Sender.Send(request);
            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        [HttpGet(ApiEndpoints.Entrance.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var request = new GetEntrancesQuery();
            EntrancesResponse response = await Sender.Send(request);
            
            return Ok(response);
        }

        [HttpGet(ApiEndpoints.Entrance.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var request = new GetSingleEntranceQuery(id);
            SingleEntranceResponse response = await Sender.Send(request);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpPut(ApiEndpoints.Entrance.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateEntranceRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            request.Id = id;
            var response = await Sender.Send(request);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpDelete(ApiEndpoints.Entrance.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var request = new DeleteEntranceRequest(id);
            bool response = await Sender.Send(request);

            if (!response)
                return NotFound();

            return Ok(response);
        }
    }
}
