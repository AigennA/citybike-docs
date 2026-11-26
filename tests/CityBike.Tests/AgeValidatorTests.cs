using CityBike.Core;
using Xunit;

namespace CityBike.Tests;

public class AgeValidatorTests
{
    private readonly AgeValidator _validator = new();
    private readonly DateOnly _today = new DateOnly(2026, 3, 19);

    [Fact]
    public void IsAdult_Turns18Tomorrow_ReturnsFalse()
    {
        bool result = _validator.IsAdult(new DateOnly(2008, 3, 20), _today);

        Assert.False(result);
    }

    [Fact]
    public void IsAdult_Turns18Today_ReturnsTrue()
    {
        bool result = _validator.IsAdult(new DateOnly(2008, 3, 19), _today);

        Assert.True(result);
    }

    [Fact]
    public void IsAdult_Turned18Yesterday_ReturnsTrue()
    {
        bool result = _validator.IsAdult(new DateOnly(2008, 3, 18), _today);

        Assert.True(result);
    }
}