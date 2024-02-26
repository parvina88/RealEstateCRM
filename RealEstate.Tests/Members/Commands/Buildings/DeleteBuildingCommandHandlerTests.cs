using RealEstate.Application.Buildings.Commands.DeleteBuilding;
using RealEstate.Contract.Building;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Exceptions;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Tests.Members.Commands.Buildings;

public class DeleteBuildingCommandHandlerTests
{
    [Fact]
    public async Task Handle_ValidRequest_ReturnsTrue()
    {
        //Arrange
        var buildingRepositoryMock = new Mock<IBuildingRepository>();
        var request = new DeleteBuildingRequest(Guid.NewGuid());
        var building = new Building()
        {
            Id = request.Id,
            Address = "Test Address",
            Name = "Test Name",
            YearOfConstruction = 2024
        };

        buildingRepositoryMock.Setup(x => x.GetAsync(request.Id)).ReturnsAsync(building);
        buildingRepositoryMock.Setup(x => x.DeleteAsync(building)).ReturnsAsync(true);

        var handler = new DeleteBuildingCommandHandler(buildingRepositoryMock.Object);

        //Act
        var result = await handler.Handle(request, CancellationToken.None);

        //Assert
        Assert.True(result);
    }

    [Fact]
    public async Task Handle_BuildingNotFound_ThrowsNotFoundException()
    {
        //Arrange
        var buildingRepositoryMock = new Mock<IBuildingRepository>();
        var request = new DeleteBuildingRequest(Guid.NewGuid());

        buildingRepositoryMock.Setup(x => x.GetAsync(request.Id)).ReturnsAsync((Building)null);

        var handler = new DeleteBuildingCommandHandler(buildingRepositoryMock.Object);

        //Act && Assert
        await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(request, CancellationToken.None));
    }
}
