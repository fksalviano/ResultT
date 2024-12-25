using FluentAssertions;
using ResultT;

namespace UnitTests;

public class ResultsTests
{
    [Fact]
    public void ShouldReturnOk()
    {
        // Act
        Result result = Results.Ok();

        // Assert
        result.Success.Should().BeTrue();

        result.Error.Should().BeNull();
        result.ErrorMessage.Should().BeNull();
    }

    [Fact]
    public void ShouldReturnOkWithObject()
    {
        // Arrange
        var obj = new object();

        // Act
        Result<object> result = Results.Ok(obj);

        // Assert
        result.Success.Should().BeTrue();

        result.Error.Should().BeNull();
        result.ErrorMessage.Should().BeNull();

    }

    [Theory]
    [InlineData(null)]
    [InlineData("message")]
    public void ShouldReturnError(string? message)
    {
        // Act
        Result result = Results.Error(message);

        // Assert
        result.Success.Should().BeFalse();

        result.Error.Should().NotBeNull();
        result.ErrorMessage.Should().Be(message);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("message")]
    public void ShouldReturnErrorWithObject(string? message)
    {
        // Act
        Result<object> result = Results.Error(message);

        // Assert
        result.Success.Should().BeFalse();

        result.Error.Should().NotBeNull();
        result.ErrorMessage.Should().Be(message);

    }
}
