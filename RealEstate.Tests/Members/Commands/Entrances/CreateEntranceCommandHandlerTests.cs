using RealEstate.Application.Entrances.Commands.CreateEntrance;
using RealEstate.Contract.Entrance;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Enums;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Tests.Entrances;

public class CreateEntranceCommandHandlerTests
{
    [Fact]
    public async Task Handle_ValidRequest_CreatesEntranceAndReturnsResponse()
    {
        // Arrange
        var buildingId = Guid.NewGuid();
        var building = new Building
        {
            Id = buildingId,
            Name = "Test Building",
            Address = "123 Main St",
            YearOfConstruction = 2022,
            ApartmentClass = ApartmentClass.Economy,
            BuildingMaterial = BuildingMaterial.Panel
        };

        var entranceRepositoryMock = new Mock<IEntranceRepository>();
        var buildingRepositoryMock = new Mock<IBuildingRepository>();
        var mapperMock = new Mock<IMapper>();

        var request = new CreateEntranceRequest
        {
            BuildingId = buildingId,
            Number = "Entrance 1",
            NumberOfFloors = 5,
            NumberOfApartmentsOnFloor = 10,
            CeilingHeight = 2.5,
            HasLift = true
        };

        buildingRepositoryMock.Setup(repo => repo.GetAsync(buildingId)).ReturnsAsync(building);
        entranceRepositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<Entrance>())).ReturnsAsync(true);

        var expectedResponse = new SingleEntranceResponse
        {
            Id = Guid.NewGuid(),
            BuildingId = buildingId,
            Number = request.Number,
            NumberOfFloors = request.NumberOfFloors,
            NumberOfApartmentsOnFloor = request.NumberOfApartmentsOnFloor,
            CeilingHeight = request.CeilingHeight,
            HasLift = request.HasLift
        };

        mapperMock.Setup(mapper => mapper.Map<SingleEntranceResponse>(It.IsAny<Entrance>())).Returns(expectedResponse);

        var handler = new CreateEntranceCommandHandler(entranceRepositoryMock.Object, buildingRepositoryMock.Object, mapperMock.Object);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedResponse.Id, result.Id);
        Assert.Equal(expectedResponse.BuildingId, result.BuildingId);
        Assert.Equal(expectedResponse.Number, result.Number);
        Assert.Equal(expectedResponse.NumberOfFloors, result.NumberOfFloors);
        Assert.Equal(expectedResponse.NumberOfApartmentsOnFloor, result.NumberOfApartmentsOnFloor);
        Assert.Equal(expectedResponse.CeilingHeight, result.CeilingHeight);
        Assert.Equal(expectedResponse.HasLift, result.HasLift);

        // Verify repository interactions
        buildingRepositoryMock.Verify(repo => repo.GetAsync(buildingId), Times.Once);
        entranceRepositoryMock.Verify(repo => repo.CreateAsync(It.IsAny<Entrance>()), Times.Once);
    }

}
