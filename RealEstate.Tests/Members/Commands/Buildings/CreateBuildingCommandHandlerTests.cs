using RealEstate.Application.Buildings.Commands.CreateBuilding;
using RealEstate.Contract.Building;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Enums;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Tests.Members.Commands.Buildings;

public class CreateBuildingCommandHandlerTests
{
    private readonly CancellationToken _token = CancellationToken.None;

    [Fact]
    public async Task Handle_ValidRequest_ReturnsSingleBuildingResponse()
    {
        // Arrange
        var buildingRepositoryMock = new Mock<IBuildingRepository>();
        var mapperMock = new Mock<IMapper>();

        var request = new CreateBuildingRequest
        {
            Name = "Test Building",
            Address = "123 Main St",
            YearOfConstruction = 2022,
            ApartmentClass = ApartmentClass.Economy,
            BuildingMaterial = BuildingMaterial.Panel
        };

        var building = new Building()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Address = request.Address,
            YearOfConstruction = request.YearOfConstruction,
            ApartmentClass = request.ApartmentClass,
            BuildingMaterial = request.BuildingMaterial
        };

        var expectedResponse = new SingleBuildingResponse
        {
            Id = building.Id,
            Name = building.Name,
            Address = building.Address,
            YearOfConstruction = building.YearOfConstruction,
            ApartmentClass = building.ApartmentClass,
            BuildingMaterial = building.BuildingMaterial
        };

        buildingRepositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<Building>(), _token)).ReturnsAsync(true);
        mapperMock.Setup(mapper => mapper.Map<SingleBuildingResponse>(It.IsAny<Building>())).Returns(expectedResponse);

        var handler = new CreateBuildingCommandHandler(buildingRepositoryMock.Object, mapperMock.Object);

        // Act
        var response = await handler.Handle(request, _token);

        // Assert
        Assert.NotNull(response);
        Assert.Equal(expectedResponse.Id, response.Id);
        Assert.Equal(expectedResponse.Name, response.Name);
        Assert.Equal(expectedResponse.Address, response.Address);
        Assert.Equal(expectedResponse.YearOfConstruction, response.YearOfConstruction);
        Assert.Equal(expectedResponse.ApartmentClass, response.ApartmentClass);
        Assert.Equal(expectedResponse.BuildingMaterial, response.BuildingMaterial);
    }
}
