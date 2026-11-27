using CityBike.Core;
using Moq;
using Xunit;

namespace CityBike.Tests;

public class BookingServiceTests
{
    private readonly Mock<IBikeRepository> _bikes = new();
    private readonly Mock<IUnlockClient> _unlockClient = new();
    private readonly BookingService _service;

    public BookingServiceTests()
    {
        _service = new BookingService(_bikes.Object, _unlockClient.Object);
    }

    //B1: En ledig cykel med tillräckligt batteri låses upp en gång.

    [Fact]
    public void Book_ValidBike_UnlocksBikeExactlyOnce()
    {
        // Arrange: cykel 1 finns och kan låsas upp

        _bikes.Setup(b => b.GetById(1)).Returns(new Bike(1, "Available", 82));
        _unlockClient.Setup(u => u.Unlock(1)).Returns(true);

        // Act: boka cykeln
        BookingResult result = _service.Book(1);

        
        // Assert: kontrollera cykeln låstes upp en gång
        
        Assert.Equal(BookingResult.Unlocked, result);
        _unlockClient.Verify(u => u.Unlock(1), Times.Once());
    }

     //B2: Cykeln finns inte, så inget låses upp.

        [Fact]
    public void Book_UnknownBike_ReturnsBikeNotFoundAndDoesNotUnlock()
    {
        _bikes.Setup(b => b.GetById(99)).Returns((Bike?)null);

        BookingResult result = _service.Book(99);

        Assert.Equal(BookingResult.BikeNotFound, result);
        _unlockClient.Verify(u => u.Unlock(It.IsAny<int>()), Times.Never());
    }

   //B3: Cykeln är redan bokad, så den låses inte upp.

    [Fact]
    public void Book_BookedBike_ReturnsBikeNotAvailableAndDoesNotUnlock()
    {
        _bikes.Setup(b => b.GetById(2)).Returns(new Bike(2, "Booked", 64));

        BookingResult result = _service.Book(2);

        Assert.Equal(BookingResult.BikeNotAvailable, result);
        _unlockClient.Verify(u => u.Unlock(It.IsAny<int>()), Times.Never());
    }

   //B4: För lite batteri (9 %), så cykeln låses inte upp.

    [Fact]
    public void Book_LowBattery_ReturnsBatteryTooLowAndDoesNotUnlock()
    {
        _bikes.Setup(b => b.GetById(3)).Returns(new Bike(3, "Available", 9));

        BookingResult result = _service.Book(3);

        Assert.Equal(BookingResult.BatteryTooLow, result);
        _unlockClient.Verify(u => u.Unlock(It.IsAny<int>()), Times.Never());
    }

     //B5: Exakt 10 % batteri räcker, gränsvärdet ska gå igenom.

        [Fact]
    public void Book_BatteryExactlyAtLimit_UnlocksBike()
    {
        _bikes.Setup(b => b.GetById(3)).Returns(new Bike(3, "Available", 10));
        _unlockClient.Setup(u => u.Unlock(3)).Returns(true);

        BookingResult result = _service.Book(3);

        Assert.Equal(BookingResult.Unlocked, result);
    }

     //B6: Upplåsningen misslyckas, så resultatet blir UnlockFailed.

    [Fact]
    public void Book_UnlockFails_ReturnsUnlockFailed()
    {
        _bikes.Setup(b => b.GetById(1)).Returns(new Bike(1, "Available", 82));
        _unlockClient.Setup(u => u.Unlock(1)).Returns(false);

        BookingResult result = _service.Book(1);

        Assert.Equal(BookingResult.UnlockFailed, result);
    }
}