using CityBike.Core;
using Xunit;

namespace CityBike.Tests;

public class PriceCalculatorTests
{
    private readonly PriceCalculator _calculator = new();

    [Fact]
    public void Calculate_18Minutes_Returns55()
    {
        decimal price = _calculator.Calculate(18 * 60);

        Assert.Equal(55m, price);
    }

[Fact]
    public void Calculate_0Seconds_ReturnsUnlockFee10()
    {
        decimal price = _calculator.Calculate(0);

        Assert.Equal(10m, price);
    }

[Fact]
    public void Calculate_100Minutes_ReturnsMaxPrice250()
    {
        decimal price = _calculator.Calculate(100 * 60);

        Assert.Equal(250m, price);
    }

[Fact]
    public void Calculate_61Seconds_Returns15()
    {
        decimal price = _calculator.Calculate(61);

        Assert.Equal(15m, price);
    }



[Fact]
    public void Calculate_NegativeSeconds_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Calculate(-1));
    }

[Theory]
    [InlineData(0, 10.0)]
          [InlineData(1, 12.5)]
            [InlineData(59, 12.5)]
              [InlineData(60, 12.5)]
            [InlineData(61, 15.0)] 
            [InlineData(120, 15.0)] 
          [InlineData(121, 17.5)]
        [InlineData(5760, 250.0)]
     [InlineData(5761, 250.0)]

    

    public void Calculate_BoundaryValues_ReturnsExpectedPrice(int seconds, double expectedPrice)
    {
        decimal price = _calculator.Calculate(seconds);
 
        Assert.Equal((decimal)expectedPrice, price);
    }

    [Fact]
    public void Calculate_MaxIntSeconds_ReturnsMaxPrice250()
    {
        decimal price = _calculator.Calculate(int.MaxValue);

        Assert.Equal(250m, price);
    }


}