using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Exceptions;
using RealEstate.Application.Data;
using RealEstate.Contract.Building;
using RealEstate.Contract.Entrance;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Entrances.Commands.CreateEntrance;

public class CreateEntranceCommandHandler : IRequestHandler<CreateEntranceRequest, SingleEntranceResponse>
{
    private readonly IEntranceRepository _entranceRepository;
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateEntranceCommandHandler(IEntranceRepository entranceRepository, IMapper mapper, IApplicationDbContext context)
    {
        _entranceRepository = entranceRepository;
        _mapper = mapper;
        _context = context;
    }


    public async Task<SingleEntranceResponse> Handle(CreateEntranceRequest request, CancellationToken cancellationToken)
    {
        var building = await _context.Buildings.FirstOrDefaultAsync(c => c.Name == request.Building);

        if (building == null)
            throw new ValidationFailedException("Building", request.Building);

        var entrance = new Entrance()
        {
            Id = Guid.NewGuid(),
            Number = request.Number,
            NumberOfFloors = request.NumberOfFloors,
            NumberOfApartmentsPerFloor = request.NumberOfApartmentsPerFloor,
            CeilingHeight = request.CeilingHeight,
            HasLift = request.HasLift,
            BuildingId = building.Id
        };

        await _entranceRepository.CreateAsync(entrance);

        return _mapper.Map<SingleEntranceResponse>(entrance);
    }
}
