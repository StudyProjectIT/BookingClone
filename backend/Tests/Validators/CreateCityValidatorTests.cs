using Application.Features.Cities.Commands.CreateCity;
using FluentAssertions;

namespace Tests.Validators;

public class CreateCityValidatorTests
{
    private readonly CreateCityValidator _validator = new();

    [Fact]
    public void Validate_ValidCommand_PassesValidation()
    {
        var command = new CreateCityCommand("Kyiv", "kyiv.jpg", 30.52, 50.45, 1);

        var result = _validator.Validate(command);

        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Validate_EmptyName_FailsValidation(string name)
    {
        var command = new CreateCityCommand(name, "kyiv.jpg", 30.52, 50.45, 1);

        var result = _validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "Name");
    }

    [Theory]
    [InlineData(181)]
    [InlineData(-181)]
    public void Validate_InvalidLongitude_FailsValidation(double longitude)
    {
        var command = new CreateCityCommand("Kyiv", "kyiv.jpg", longitude, 50.45, 1);

        var result = _validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "Longitude");
    }

    [Theory]
    [InlineData(91)]
    [InlineData(-91)]
    public void Validate_InvalidLatitude_FailsValidation(double latitude)
    {
        var command = new CreateCityCommand("Kyiv", "kyiv.jpg", 30.52, latitude, 1);

        var result = _validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "Latitude");
    }

    [Fact]
    public void Validate_ZeroCountryId_FailsValidation()
    {
        var command = new CreateCityCommand("Kyiv", "kyiv.jpg", 30.52, 50.45, 0);

        var result = _validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "CountryId");
    }
}
