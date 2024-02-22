using AutoMapper;
using MediatR;
using RealEstate.Application.Common.Exceptions;
using RealEstate.Contract.Apartment;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Apartments.Commands.CreateApartment;

public class CreateApartmentCommandHandler : IRequestHandler<CreateApartmentRequest, SingleApartmentResponse>
{
    private readonly IApartmentRepository _apartmentRepository;
    private readonly IEntranceRepository _entranceRepository;
    private readonly IMapper _mapper;

    public CreateApartmentCommandHandler(IApartmentRepository apartmentRepository, IEntranceRepository entranceRepository, IMapper mapper)
    {
        _apartmentRepository = apartmentRepository;
        _entranceRepository = entranceRepository;
        _mapper = mapper;
    }

    public async Task<SingleApartmentResponse> Handle(CreateApartmentRequest request, CancellationToken cancellationToken)
    {
        var entrance = await _entranceRepository.GetAsync(request.EntranceId) ?? throw new NotFoundException(nameof(Entrance), request.EntranceId);

        var apartment = new Apartment()
        {
            Id = Guid.NewGuid(),
            Number = request.Number,
            Floor = request.Floor,
            NumberOfRooms = request.NumberOfRooms,
            TotalArea = request.TotalArea,
            LivingArea = request.LivingArea,
            PricePerSquare = request.PricePerSquare,
            Type = request.Type,
            Status = request.Status,
            EntranceId = entrance.Id
        };

        await _apartmentRepository.CreateAsync(apartment);

        return _mapper.Map<SingleApartmentResponse>(apartment);
    }
}
