using RealEstate.Application.Apartments.Commands.DeleteApartment;
using RealEstate.Contract.Apartment;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Enums;
using RealEstate.Domain.Exceptions;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Tests.Apartments.Commands
{
    public class DeleteApartmentCommandHandlerTests
    {
        private readonly CancellationToken _token = CancellationToken.None;

        [Fact]
        public async Task Handle_ValidRequest_DeletesApartment()
        {
            // Arrange
            var apartmentRepositoryMock = new Mock<IApartmentRepository>();
            var request = new DeleteApartmentRequest(Guid.NewGuid());
            var apartment = new Apartment
            {
                Id = request.Id,
                Number = "101",
                Floor = 1,
                TotalArea = 80.5,
                LivingArea = 70.0,
                PricePerSquare = 1500.0m,
                Type = ApartmentType.TwoBedroom,
                Status = ApartmentStatus.Available
            };

            apartmentRepositoryMock.Setup(repo => repo.GetAsync(request.Id, _token)).ReturnsAsync(apartment);
            apartmentRepositoryMock.Setup(repo => repo.DeleteAsync(apartment, _token)).ReturnsAsync(true);

            var handler = new DeleteApartmentCommandHandler(apartmentRepositoryMock.Object);

            // Act
            var result = await handler.Handle(request, _token);

            // Assert
            Assert.True(result);
            apartmentRepositoryMock.Verify(repo => repo.DeleteAsync(apartment, _token), Times.Once);
        }


        [Fact]
        public async Task Handle_NonExistingApartment_ThrowsNotFoundException()
        {
            // Arrange
            var apartmentId = Guid.NewGuid();
            var request = new DeleteApartmentRequest(apartmentId);

            var apartmentRepositoryMock = new Mock<IApartmentRepository>();
            apartmentRepositoryMock.Setup(repo => repo.GetAsync(apartmentId, _token)).ReturnsAsync((Apartment)null);

            var handler = new DeleteApartmentCommandHandler(apartmentRepositoryMock.Object);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(request, _token));
        }
    }
}
