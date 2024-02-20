using Microsoft.AspNetCore.Mvc;
using RealEstate.Contract.Building;
using RealEstate.Contract.Entrance;

namespace RealEstate.Api.Controllers
{
    public class EntranceController : ApiControllerBase
    {
        [HttpPost(ApiEndpoints.Entrance.Create)]
        public async Task<SingleEntranceResponse> Create(CreateEntranceRequest request)
        {
            return await Sender.Send(request);
        }

        [HttpGet(ApiEndpoints.Entrance.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var request = new GetEntrancesQuery();
            var response = await Sender.Send(request);
            
            return Ok(response);
        }

        [HttpGet(ApiEndpoints.Entrance.Get)]
        public async Task<IActionResult> Get(Guid id)
        {
            var request = new GetSingleEntranceQuery()
            {
                EntranceId = id
            };

            var response = await Sender.Send(request);

            if (response == null)
                return NotFound();
            
            return Ok(response);
        }
    }
}
