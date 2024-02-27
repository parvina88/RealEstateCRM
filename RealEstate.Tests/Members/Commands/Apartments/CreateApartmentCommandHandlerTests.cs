using RealEstate.Application.Apartments.Commands.CreateApartment;
using RealEstate.Contract.Apartment;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Enums;
using RealEstate.Domain.Exceptions;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Tests.Apartments.Commands
{
    public class CreateApartmentCommandHandlerTests
    {
        private readonly CancellationToken _token = CancellationToken.None;

        [Fact]
        public async Task Handle_ValidRequest_ReturnsSingleApartmentResponse()
        {
            // Arrange
            var entranceId = Guid.NewGuid();
            var request = new CreateApartmentRequest
            {
                EntranceId = entranceId,
                Number = "101",
                Floor = 1,
                NumberOfRooms = 2,
                TotalArea = 80.5,
                LivingArea = 70.0,
                PricePerSquare = 1500.0m,
                Type = ApartmentType.TwoBedroom,
                Status = ApartmentStatus.Available
            };

            var entranceRepositoryMock = new Mock<IEntranceRepository>();
            entranceRepositoryMock.Setup(repo => repo.GetAsync(entranceId, _token)).ReturnsAsync(new Entrance { Id = entranceId });

            var apartmentRepositoryMock = new Mock<IApartmentRepository>();
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<SingleApartmentResponse>(It.IsAny<Apartment>())).Returns(new SingleApartmentResponse());

            var handler = new CreateApartmentCommandHandler(apartmentRepositoryMock.Object, entranceRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = await handler.Handle(request, _token);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<SingleApartmentResponse>(result);
        }

        [Fact]
        public async Task Handle_InvalidEntranceId_ThrowsNotFoundException()
        {
            // Arrange
            var entranceId = Guid.NewGuid();
            var request = new CreateApartmentRequest { EntranceId = entranceId };

            var entranceRepositoryMock = new Mock<IEntranceRepository>();
            entranceRepositoryMock.Setup(repo => repo.GetAsync(entranceId, _token)).ReturnsAsync((Entrance)null);

            var apartmentRepositoryMock = new Mock<IApartmentRepository>();
            var mapperMock = new Mock<IMapper>();

            var handler = new CreateApartmentCommandHandler(apartmentRepositoryMock.Object, entranceRepositoryMock.Object, mapperMock.Object);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(request,_token));
        }
    }
}

