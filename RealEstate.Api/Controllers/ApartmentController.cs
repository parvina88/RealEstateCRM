using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Services;

namespace RealEstate.Api.Controllers;

[ApiController]
public class ApartmentController : ApiControllerBase
{
    private readonly IBuildingService _service;

    public ApartmentController(IBuildingService service)
    {
        _service = service;
    }

}