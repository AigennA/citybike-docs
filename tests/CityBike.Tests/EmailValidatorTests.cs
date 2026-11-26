using CityBike.Core;
using Xunit;

namespace CityBike.Tests;

public class EmailValidatorTests
{
    private readonly EmailValidator _validator = new();

    [Fact]
    public void IsValid_CorrectEmail_ReturnsTrue()
    {
        bool result = _validator.IsValid("anna@stad.se");

        Assert.True(result);
    }

    [Theory]
    [InlineData("anna@")]
    [InlineData("anna@.")]
    [InlineData("@stad.se")]
    [InlineData("")]
    public void IsValid_InvalidEmail_ReturnsFalse(string email)
    {
        bool result = _validator.IsValid(email);

        Assert.False(result);
    }
}