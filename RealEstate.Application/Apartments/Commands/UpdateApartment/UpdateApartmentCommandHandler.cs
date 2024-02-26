using AutoMapper;
using MediatR;
using RealEstate.Contract.Apartment;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Exceptions;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Apartments.Commands.UpdateApartment;

public class UpdateApartmentCommandHandler(IApartmentRepository apartmentRepository, IMapper mapper) : IRequestHandler<UpdateApartmentRequest, SingleApartmentResponse>
{
    private readonly IApartmentRepository _apartmentRepository = apartmentRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<SingleApartmentResponse> Handle(UpdateApartmentRequest request, CancellationToken cancellationToken)
    {
        var apartment = await _apartmentRepository.GetAsync(request.Id) ?? throw new NotFoundException(nameof(Apartment), request.Id);

        apartment.Number = request.Number;
        apartment.Floor = request.Floor;
        apartment.NumberOfRooms = request.NumberOfRooms;
        apartment.TotalArea = request.TotalArea;
        apartment.LivingArea = request.LivingArea;
        apartment.PricePerSquare = request.PricePerSquare;
        apartment.Type = request.Type;
        apartment.Status = request.Status;
        apartment.EntranceId = request.EntranceId;

        await _apartmentRepository.UpdateAsync(apartment);

        return _mapper.Map<SingleApartmentResponse>(apartment);
    }
}
