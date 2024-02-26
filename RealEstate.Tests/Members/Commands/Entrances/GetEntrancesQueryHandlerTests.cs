using RealEstate.Application.Entrances.Queries.GetEntrances;
using RealEstate.Contract.Entrance;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Tests.Members.Commands.Entrances;

public class GetEntrancesQueryHandlerTests
{
    [Fact]
    public async Task Handle_ValidRequest_ReturnsEntrancesResponse()
    {
        // Arrange
        var entrances = new List<Entrance>
            {
                new Entrance { Id = Guid.NewGuid(), Number = "Entrance 1" },
                new Entrance { Id = Guid.NewGuid(), Number = "Entrance 2" }
            };

        var entranceRepositoryMock = new Mock<IEntranceRepository>();
        entranceRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(entrances);

        var mapperMock = new Mock<IMapper>();
        EntrancesResponse expectedResponse = new EntrancesResponse { Items = new List<SingleEntranceResponse>() };
        foreach (var entrance in entrances)
        {
            expectedResponse.Items.ToList().Add(new SingleEntranceResponse { Id = entrance.Id, Number = entrance.Number });
        }
        mapperMock.Setup(mapper => mapper.Map<IEnumerable<SingleEntranceResponse>>(entrances)).Returns(expectedResponse.Items);

        var handler = new GetEntrancesQueryHandler(entranceRepositoryMock.Object, mapperMock.Object);
        var request = new GetEntrancesQuery();

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        foreach (var expectedItem in expectedResponse.Items)
        {
            Assert.Contains(result.Items, actualItem => actualItem.Id == expectedItem.Id && actualItem.Number == expectedItem.Number);
        }
    }
}

