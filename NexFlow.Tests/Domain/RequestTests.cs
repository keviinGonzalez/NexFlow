using NexFlow.Domain.Entities;
using NexFlow.Domain.Exceptions;

namespace NexFlow.Tests.Domain.Entities;

public class RequestTests
{
    [Fact]
    public void Constructor_Should_Create_Request_When_Data_Is_Valid()
    {
        // Arrange
        var title = "Solicitud de vacaciones";
        var description = "Vacaciones del 1 al 15.";

        // Act
        var request = new Request(title, description);

        // Assert
        Assert.Equal(title, request.Title);
        Assert.Equal(description, request.Description);
        Assert.NotEqual(Guid.Empty, request.Id);
        Assert.NotEqual(default, request.CreatedAt);
        Assert.Null(request.UpdatedAt);
    }

    [Fact]
    public void Constructor_Should_Throw_DomainException_When_Title_Is_Required()
    {
        // Arrange
        var title = string.Empty;
        var description = "Descripción";

        // Act
        var exception = Assert.Throws<DomainException>(() =>
            new Request(title, description));

        // Assert
        Assert.Equal("title is required.", exception.Message);
    }

    [Fact]
    public void Constructor_Should_Throw_DomainException_When_Title_Exceeds_Max_Length()
    {
        // Arrange
        var title = new string('A', 151);
        var description = "Descripción";

        // Act
        var exception = Assert.Throws<DomainException>(() =>
            new Request(title, description));

        // Assert
        Assert.Equal("title cannot exceed 150 characters.", exception.Message);
    }

    [Fact]
    public void Constructor_Should_Throw_DomainException_When_Description_Exceeds_Max_Length()
    {
        // Arrange
        var title = "Solicitud";
        var description = new string('A', 1001);

        // Act
        var exception = Assert.Throws<DomainException>(() =>
            new Request(title, description));

        // Assert
        Assert.Equal("description cannot exceed 1000 characters.", exception.Message);
    }

    [Fact]
    public void Update_Should_Update_Request_When_Data_Is_Valid()
    {
        // Arrange
        var request = new Request(
            "Solicitud",
            "Descripción");

        // Act
        request.Update(
            "Solicitud Actualizada",
            "Nueva descripción");

        // Assert
        Assert.Equal("Solicitud Actualizada", request.Title);
        Assert.Equal("Nueva descripción", request.Description);
        Assert.NotNull(request.UpdatedAt);
    }

    [Fact]
    public void Update_Should_Throw_DomainException_When_Title_Is_Required()
    {
        // Arrange
        var request = new Request(
            "Solicitud",
            "Descripción");

        // Act
        var exception = Assert.Throws<DomainException>(() =>
            request.Update(string.Empty, "Nueva descripción"));

        // Assert
        Assert.Equal("title is required.", exception.Message);
    }

    [Fact]
    public void Update_Should_Throw_DomainException_When_Title_Exceeds_Max_Length()
    {
        // Arrange
        var request = new Request(
            "Solicitud",
            "Descripción");

        var title = new string('A', 151);

        // Act
        var exception = Assert.Throws<DomainException>(() =>
            request.Update(title, "Nueva descripción"));

        // Assert
        Assert.Equal("title cannot exceed 150 characters.", exception.Message);
    }

    [Fact]
    public void Update_Should_Throw_DomainException_When_Description_Exceeds_Max_Length()
    {
        // Arrange
        var request = new Request(
            "Solicitud",
            "Descripción");

        var description = new string('A', 1001);

        // Act
        var exception = Assert.Throws<DomainException>(() =>
            request.Update("Solicitud", description));

        // Assert
        Assert.Equal("description cannot exceed 1000 characters.", exception.Message);
    }
}