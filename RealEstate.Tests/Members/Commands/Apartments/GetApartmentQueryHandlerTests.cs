using RealEstate.Application.Apartments.Queries.GetApartment;
using RealEstate.Contract.Apartment;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Enums;
using RealEstate.Domain.Exceptions;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Tests.Members.Commands.Apartments;

public class GetApartmentQueryHandlerTests
{
    [Fact]
    public async Task Handle_ValidRequest_ReturnsSingleApartmentResponse()
    {
        // Arrange
        var apartmentId = Guid.NewGuid();
        var request = new GetSingleApartmentRequest(apartmentId);

        var apartment = new Apartment
        {
            Id = apartmentId,
            Number = "101",
            Floor = 1,
            NumberOfRooms = 2,
            TotalArea = 80.5,
            LivingArea = 70.0,
            PricePerSquare = 1500.0m,
            Type = ApartmentType.TwoBedroom,
            Status = ApartmentStatus.Available
        };

        var apartmentRepositoryMock = new Mock<IApartmentRepository>();
        apartmentRepositoryMock.Setup(repo => repo.GetAsync(apartmentId)).ReturnsAsync(apartment);

        var mapperMock = new Mock<IMapper>();
        var expectedResponse = new SingleApartmentResponse { Id = apartmentId }; // Create a response with expected values
        mapperMock.Setup(mapper => mapper.Map<SingleApartmentResponse>(apartment)).Returns(expectedResponse);

        var handler = new GetApartmentQueryHandler(apartmentRepositoryMock.Object, mapperMock.Object);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(apartmentId, result.Id);
        // Ensure other properties are also mapped correctly
    }

    [Fact]
    public async Task Handle_ApartmentNotFound_ThrowsNotFoundException()
    {
        // Arrange
        var apartmentId = Guid.NewGuid();
        var request = new GetSingleApartmentRequest(apartmentId);

        var apartmentRepositoryMock = new Mock<IApartmentRepository>();
        apartmentRepositoryMock.Setup(repo => repo.GetAsync(apartmentId)).ReturnsAsync((Apartment)null);

        var mapperMock = new Mock<IMapper>();
        var handler = new GetApartmentQueryHandler(apartmentRepositoryMock.Object, mapperMock.Object);

        // Act and Assert
        await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(request, CancellationToken.None));
    }

}
