using RealEstate.Application.Entrances.Queries.GetEntranceDetail;
using RealEstate.Contract.Entrance;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Tests.Entrances;

public class GetEntranceDetailQueryHandlerTests
{
    [Fact]
    public async Task Handle_ValidRequest_ReturnsSingleEntranceResponse()
    {
        // Arrange
        var entranceId = Guid.NewGuid();
        var entrance = new Entrance
        {
            Id = entranceId,
            Number = "Entrance 1"
        };

        var entranceRepositoryMock = new Mock<IEntranceRepository>();
        entranceRepositoryMock.Setup(repo => repo.GetAsync(entranceId)).ReturnsAsync(entrance);

        var mapperMock = new Mock<IMapper>();
        var expectedResponse = new SingleEntranceResponse
        {
            Id = entrance.Id,
            Number = entrance.Number
        };
        mapperMock.Setup(mapper => mapper.Map<SingleEntranceResponse>(entrance)).Returns(expectedResponse);

        var handler = new GetEntranceDetailQueryHandler(entranceRepositoryMock.Object, mapperMock.Object);
        var request = new GetSingleEntranceQuery(entranceId);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(entrance.Id, result.Id);
        Assert.Equal(entrance.Number, result.Number);
    }
}
