using RealEstate.Application.Apartments.Commands.UpdateApartment;
using RealEstate.Contract.Apartment;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Enums;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Tests.Members.Commands.Apartments;

public class UpdateApartmentHandlerTests
{
    private readonly CancellationToken _token = CancellationToken.None;

    [Fact]
    public async Task Handle_ValidRequest_ReturnsTrue()
    {
        // Arrange
        var request = new UpdateApartmentRequest
        {
            Id = Guid.NewGuid(),
            Number = "1",
            Floor = 1,
            EntranceId = Guid.NewGuid(),
            Status = ApartmentStatus.Available
        };
        var apartment = new Apartment
        {
            Id = request.Id,
            Number = request.Number,
            Floor = request.Floor,
            EntranceId = request.EntranceId,
            Status = request.Status
        };

        var apartmentRepositoryMock = new Mock<IApartmentRepository>();

        apartmentRepositoryMock.Setup(x => x.GetAsync(request.Id, _token)).ReturnsAsync(apartment);
        apartmentRepositoryMock.Setup(x => x.UpdateAsync(apartment, _token)).ReturnsAsync(true);

        var mapperMock = new Mock<IMapper>();
        var expectedResponse = new SingleApartmentResponse();
        mapperMock.Setup(mapper => mapper.Map<SingleApartmentResponse>(apartment)).Returns(expectedResponse);
        var handler = new UpdateApartmentCommandHandler(apartmentRepositoryMock.Object, mapperMock.Object);


        // Act
        var result = await handler.Handle(request, _token);


        // Assert
        Assert.NotNull(result);
        Assert.Equal(request.Number, apartment.Number);
        Assert.Equal(request.Floor, apartment.Floor);
        Assert.Equal(request.NumberOfRooms, apartment.NumberOfRooms);
        Assert.Equal(request.TotalArea, apartment.TotalArea);
        Assert.Equal(request.LivingArea, apartment.LivingArea);
        Assert.Equal(request.PricePerSquare, apartment.PricePerSquare);
        Assert.Equal(request.Type, apartment.Type);
        Assert.Equal(request.Status, apartment.Status);
        Assert.Equal(request.EntranceId, apartment.EntranceId);

        apartmentRepositoryMock.Verify(repo => repo.UpdateAsync(apartment, _token), Times.Once);
    }
}
