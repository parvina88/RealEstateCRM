using RealEstate.Application.Buildings.Commands.UpdateBuilding;
using RealEstate.Contract.Building;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Enums;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Tests.Members.Commands.Buildings
{
    public class UpdateBuildingCommandHandlerTests
    {
        private readonly CancellationToken _token = CancellationToken.None;

        [Fact]
        public async Task Handle_UpdateBuildingCommandHandler_ShouldUpdateBuildingAndReturnSingleBuildingResponse()
        {
            // Arrange
            var buildingId = Guid.NewGuid();
            var request = new UpdateBuildingRequest
            {
                Id = buildingId,
                Name = "New Building Name",
                Address = "New Building Address",
                YearOfConstruction = 2022,
                ApartmentClass = ApartmentClass.Business,
                BuildingMaterial = BuildingMaterial.Brick
            };
            var updatedBuilding = new Building
            {
                Id = buildingId,
                Name = request.Name,
                Address = request.Address,
                YearOfConstruction = request.YearOfConstruction,
                ApartmentClass = request.ApartmentClass,
                BuildingMaterial = request.BuildingMaterial
            };
            var buildingRepositoryMock = new Mock<IBuildingRepository>();
            var mapperMock = new Mock<IMapper>();
            var handler = new UpdateBuildingCommandHandler(buildingRepositoryMock.Object, mapperMock.Object);

            buildingRepositoryMock.Setup(repo => repo.GetAsync(buildingId, _token)).ReturnsAsync(updatedBuilding);
            buildingRepositoryMock.Setup(repo => repo.UpdateAsync(updatedBuilding, _token)).ReturnsAsync(true);

            mapperMock.Setup(mapper => mapper.Map<SingleBuildingResponse>(updatedBuilding))
                .Returns(new SingleBuildingResponse
                {
                    Id = updatedBuilding.Id,
                    Name = updatedBuilding.Name,
                    Address = updatedBuilding.Address,
                    YearOfConstruction = updatedBuilding.YearOfConstruction,
                    ApartmentClass = updatedBuilding.ApartmentClass,
                    BuildingMaterial = updatedBuilding.BuildingMaterial
                });

            // Act
            var result = await handler.Handle(request, _token);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(request.Name, result.Name);
            Assert.Equal(request.Address, result.Address);
            Assert.Equal(request.YearOfConstruction, result.YearOfConstruction);
            Assert.Equal(request.ApartmentClass, result.ApartmentClass);
            Assert.Equal(request.BuildingMaterial, result.BuildingMaterial);
        }
    }
}
