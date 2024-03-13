using RealEstate.Application.Buildings.Queries.GetBuildingDetails;
using RealEstate.Contract.Building;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Exceptions;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Tests.Members.Commands.Buildings;

public class GetBuildingDetailQueryHandlerTests
{
    private readonly CancellationToken _token = CancellationToken.None;

    [Fact]
    public async Task Handle_ValidRequest_ReturnsSingleBuildingResponse()
    {
        // Arrange
        var buildingId = Guid.NewGuid();
        var request = new GetSingleBuildingQuery(buildingId);
        var building = new Building { Id = buildingId, Name = "Test Building" };

        var buildingRepositoryMock = new Mock<IBuildingRepository>();
        buildingRepositoryMock.Setup(repo => repo.GetAsync(buildingId, _token)).ReturnsAsync(building);

        var mapperMock = new Mock<IMapper>();
        var expectedResponse = new SingleBuildingResponse { Id = building.Id, Name = building.Name };
        mapperMock.Setup(mapper => mapper.Map<SingleBuildingResponse>(building)).Returns(expectedResponse);

        var handler = new GetBuildingDetailQueryHandler(buildingRepositoryMock.Object, mapperMock.Object);

        // Act
        SingleBuildingResponse result = await handler.Handle(request, _token);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(building.Id, result.Id);
        Assert.Equal(building.Name, result.Name);
    }

    [Fact]
    public async Task Handle_InvalidRequest_ThrowsNotFoundException()
    {
        // Arrange
        var buildingId = Guid.NewGuid();
        var request = new GetSingleBuildingQuery(buildingId);

        var buildingRepositoryMock = new Mock<IBuildingRepository>();
        buildingRepositoryMock.Setup(repo => repo.GetAsync(buildingId, _token)).ReturnsAsync((Building)null);

        var mapperMock = new Mock<IMapper>();
        var handler = new GetBuildingDetailQueryHandler(buildingRepositoryMock.Object, mapperMock.Object);

        // Act and Assert
        await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(request, _token));
    }
}
