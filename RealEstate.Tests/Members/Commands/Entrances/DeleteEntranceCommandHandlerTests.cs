using RealEstate.Application.Entrances.Commands.DeleteEntrance;
using RealEstate.Contract.Entrance;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Exceptions;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Tests.Entrances;

public class DeleteEntranceCommandHandlerTests
{
    private readonly CancellationToken _token = CancellationToken.None;

    [Fact]
    public async Task Handle_ValidRequest_DeletesEntrance()
    {
        // Arrange
        var entranceId = Guid.NewGuid();
        var request = new DeleteEntranceRequest(entranceId);

        var entrance = new Entrance
        {
            Id = entranceId
        };

        var entranceRepositoryMock = new Mock<IEntranceRepository>();
        entranceRepositoryMock.Setup(repo => repo.GetAsync(entranceId, _token)).ReturnsAsync(entrance);
        entranceRepositoryMock.Setup(repo => repo.DeleteAsync(entrance, _token)).ReturnsAsync(true);

        var handler = new DeleteEntranceCommandHandler(entranceRepositoryMock.Object);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.True(result);

        // Verify that the repository methods were called with the correct arguments
        entranceRepositoryMock.Verify(repo => repo.GetAsync(entranceId, _token), Times.Once);
        entranceRepositoryMock.Verify(repo => repo.DeleteAsync(entrance, _token), Times.Once);
    }

    [Fact]
    public async Task Handle_InvalidRequest_ThrowsNotFoundException()
    {
        // Arrange
        var entranceId = Guid.NewGuid();
        var request = new DeleteEntranceRequest(entranceId);

        var entranceRepositoryMock = new Mock<IEntranceRepository>();
        entranceRepositoryMock.Setup(repo => repo.GetAsync(entranceId, _token)).ReturnsAsync((Entrance)null);

        var handler = new DeleteEntranceCommandHandler(entranceRepositoryMock.Object);

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(request, CancellationToken.None));

        // Verify that the repository method was called with the correct argument
        entranceRepositoryMock.Verify(repo => repo.GetAsync(entranceId, _token), Times.Once);
        entranceRepositoryMock.Verify(repo => repo.DeleteAsync(It.IsAny<Entrance>(), _token), Times.Never);
    }
}
