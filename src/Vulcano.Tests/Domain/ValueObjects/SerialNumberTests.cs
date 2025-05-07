using System;
using Vulcano.Domain.ValueObjects;
using Xunit;

namespace Vulcano.Tests.Domain.ValueObjects;

public class SerialNumberTests
{
    [Fact]
    public void Should_Create_SerialNumber_When_Value_Is_Valid()
    {
        // Arrange
        string input = "abc123";

        // Act
        var serial = new SerialNumber(input);

        // Assert
        Assert.Equal("ABC123", serial.Value); // Deve ser convertido para uppercase
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    [InlineData("A1")] // Muito curto
    public void Should_Throw_Exception_When_Value_Is_Invalid(string invalidInput)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new SerialNumber(invalidInput));
    }

    [Fact]
    public void Should_Compare_SerialNumbers_By_Value()
    {
        // Arrange
        var sn1 = new SerialNumber("abc123");
        var sn2 = new SerialNumber("ABC123");

        // Act & Assert
        Assert.Equal(sn1, sn2);
        Assert.True(sn1.Equals(sn2));
        Assert.Equal(sn1.GetHashCode(), sn2.GetHashCode());
    }
}
