﻿using Microsoft.AspNetCore.Mvc;
using RealEstate.Contract.Apartment;
using RealEstate.Domain.Enums;

namespace RealEstate.Api.Controllers;

[ApiController]
public class ApartmentController : ApiControllerBase
{
    [HttpPost(ApiEndpoints.Apartment.Create)]
    public async Task<IActionResult> Create([FromBody] CreateApartmentRequest request)
    {
        var response = await Sender.Send(request);

        return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
    }

    [HttpGet(ApiEndpoints.Apartment.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var request = new GetApartmentsQuery();
        var response = await Sender.Send(request);

        return response == null ? NotFound() : Ok(response);
    }

    [HttpGet(ApiEndpoints.Apartment.GetAllByEntrance)]
    public async Task<IActionResult> GetAllByEntrance([FromRoute] Guid id)
    {
        var request = new GetApartmentsByEntranceQuery(id);
        var response = await Sender.Send(request);

        return response == null ? NotFound("No apartments found in this entrance.") : Ok(response);
    }

    [HttpGet(ApiEndpoints.Apartment.GetAllByStatus)]
    public async Task<IActionResult> GetAllByStatus([FromRoute] ApartmentStatus status)
    {
        var request = new GetApartmentsByStatusQuery(status);
        var response = await Sender.Send(request);

        return response == null ? NotFound("No apartments found with the specified status.") : Ok(response);
    }

    [HttpGet(ApiEndpoints.Apartment.Get)]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var request = new GetSingleApartmentRequest(id);
        var response = await Sender.Send(request);

        return response == null ? NotFound("Apartment not found") : Ok(response);
    }

    [HttpPut(ApiEndpoints.Apartment.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateApartmentRequest request)
    {
        if (request == null)
        {
            return BadRequest("Invalid request data.");
        }

        request.Id = id;
        var response = await Sender.Send(request);

        return response == null ? NotFound() : Ok(response);
    }

    [HttpDelete(ApiEndpoints.Apartment.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var request = new DeleteApartmentRequest(id);
        var response = await Sender.Send(request);

        return response ? Ok() : NotFound($"Apartment with ID {id} not found.");
    }
}