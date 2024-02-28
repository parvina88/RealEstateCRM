using AutoMapper;
using RealEstate.Contract.Apartment;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Common.Mapping;

public class ApartmentMapProfile : Profile
{
    public ApartmentMapProfile()
    {
        CreateMap<Apartment, SingleApartmentResponse>();
        CreateMap<CreateApartmentRequest, Apartment>();
        CreateMap<GetApartmentsQuery, ApartmentsResponse>();
        CreateMap<UpdateApartmentRequest, Apartment>();
    }
}
