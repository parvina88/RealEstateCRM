using RealEstate.Application.Entrances.Commands.UpdateEntrance;
using RealEstate.Contract.Entrance;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Tests.Entrances;

public class UpdateEntranceCommandHandlerTests
{
    private readonly CancellationToken _token = CancellationToken.None;

    [Fact]
    public async Task Handle_ValidRequest_ReturnsSingleEntranceResponse()
    {
        // Arrange
        var entranceId = Guid.NewGuid();
        var request = new UpdateEntranceRequest
        {
            Id = entranceId,
            Number = "1",
            BuildingId = Guid.NewGuid(),
            NumberOfFloors = 5
        };

        var entrance = new Entrance
        {
            Id = entranceId,
            Number = request.Number,
            BuildingId = request.BuildingId,
            NumberOfFloors = request.NumberOfFloors
        };

        var entranceRepositoryMock = new Mock<IEntranceRepository>();
        entranceRepositoryMock.Setup(repo => repo.GetAsync(entranceId, _token)).ReturnsAsync(entrance);
        entranceRepositoryMock.Setup(repo => repo.UpdateAsync(entrance, _token)).ReturnsAsync(true);

        var mapperMock = new Mock<IMapper>();
        var expectedResponse = new SingleEntranceResponse
        {
            Id = entrance.Id,
            Number = entrance.Number,
            BuildingId = entrance.BuildingId,
            NumberOfFloors = entrance.NumberOfFloors
        };

        mapperMock.Setup(mapper => mapper.Map<SingleEntranceResponse>(entrance)).Returns(expectedResponse);

        var handler = new UpdateEntranceCommandHandler(entranceRepositoryMock.Object, mapperMock.Object);

        // Act
        var result = await handler.Handle(request, _token);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedResponse.Id, result.Id);
        Assert.Equal(expectedResponse.Number, result.Number);
        Assert.Equal(expectedResponse.BuildingId, result.BuildingId);
        Assert.Equal(expectedResponse.NumberOfFloors, result.NumberOfFloors);

        entranceRepositoryMock.Verify(repo => repo.GetAsync(entranceId, _token), Times.Once);
        entranceRepositoryMock.Verify(repo => repo.UpdateAsync(entrance, _token), Times.Once);
    }
}
