using FluentAssertions;
using ResultT;
using static ResultT.Results;

namespace UnitTests;

public class ResultsTests
{
    [Fact]
    public void ShouldReturnOk()
    {
        // Act
        Result result = Ok();

        // Assert
        result.Success.Should().BeTrue();

        result.Error.Should().BeNull();
        result.ErrorMessage.Should().BeNull();
    }

    [Fact]
    public void ShouldReturnOkWithObject()
    {
        // Arrange
        var value = new object();

        // Act
        Result<object> result = Ok(value);

        // Assert
        result.Success.Should().BeTrue();

        result.Error.Should().BeNull();
        result.ErrorMessage.Should().BeNull();

    }

    [Fact]
    public void ShouldReturnOkValueObject()
    {
        // Arrange
        var value = new object();

        // Act
        Result<object> result = value;

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
        Result result = Error(message);

        // Assert
        result.Success.Should().BeFalse();

        result.Error.Should().NotBeNull();
        result.ErrorMessage.Should().Be(message);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("message")]
    public void ShouldReturnErrorWithObject(string? errorMessage)
    {
        // Act
        Result<object> result = Error(errorMessage);

        // Assert
        result.Success.Should().BeFalse();

        result.Error.Should().NotBeNull();
        result.ErrorMessage.Should().Be(errorMessage);

    }



    [Fact]    
    public void ShouldReturnErrorException()
    {
        //Arrange        
        var exception = new Exception("errorMessage");

        // Act
        Result result = Error(exception);

        // Assert
        result.Success.Should().BeFalse();

        result.Error.Should().NotBeNull();
        result.Error!.Exception.Should().Be(exception);
        result.ErrorMessage.Should().Be(exception.Message);
    }

    [Fact]
    public void ShouldReturnErrorExceptionWithObject()
    {
        //Arrange        
        var exception = new Exception("errorMessage");

        // Act
        Result<object> result = Error(exception);

        // Assert
        result.Success.Should().BeFalse();

        result.Error.Should().NotBeNull();
        result.Error!.Exception.Should().Be(exception);
        result.ErrorMessage.Should().Be(exception.Message);

    }    



    [Fact]    
    public void ShouldReturnErrorMessage()
    {
        //Arrange
        var errorMessage = "errorMessage";

        // Act
        Result result = errorMessage;

        // Assert
        result.Success.Should().BeFalse();

        result.Error.Should().NotBeNull();
        result.ErrorMessage.Should().Be(errorMessage);
    }

    [Fact]
    public void ShouldReturnErrorMessageWithObject()
    {
        //Arrange
        var errorMessage = "errorMessage";

        // Act
        Result<object> result = errorMessage;

        // Assert
        result.Success.Should().BeFalse();

        result.Error.Should().NotBeNull();
        result.ErrorMessage.Should().Be(errorMessage);

    }



    [Fact]    
    public void ShouldReturnExceptionMessage()
    {
        //Arrange
        var exception = new Exception("errorMessage");

        // Act
        Result result = exception;

        // Assert
        result.Success.Should().BeFalse();

        result.Error.Should().NotBeNull();
        result.Error!.Exception.Should().Be(exception);
        result.ErrorMessage.Should().Be(exception.Message);                
    }

    [Fact]
    public void ShouldReturnExceptionMessageWithObject()
    {
        //Arrange
        var exception = new Exception("errorMessage");

        // Act
        Result<object> result = exception;

        // Assert
        result.Success.Should().BeFalse();

        result.Error.Should().NotBeNull();
        result.Error!.Exception.Should().Be(exception);
        result.ErrorMessage.Should().Be(exception.Message);                
    }
}
