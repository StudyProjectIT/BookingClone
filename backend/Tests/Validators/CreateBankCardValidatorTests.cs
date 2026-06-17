using Application.Features.BankCards.Commands.CreateBankCard;
using FluentAssertions;

namespace Tests.Validators;

public class CreateBankCardValidatorTests
{
    private readonly CreateBankCardValidator _validator = new();

    [Fact]
    public void Validate_ValidCommand_PassesValidation()
    {
        var command = new CreateBankCardCommand(
            Number: "4111111111111111",
            Cvv: "123",
            OwnerFullName: "John Doe",
            ExpirationDate: DateOnly.FromDateTime(DateTime.UtcNow.AddYears(2)),
            CustomerId: 1
        );

        var result = _validator.Validate(command);

        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData("123")]        // Too short (< 13)
    [InlineData("12345678901234567890")]  // Too long (> 19)
    public void Validate_InvalidCardNumber_FailsValidation(string number)
    {
        var command = new CreateBankCardCommand(
            Number: number,
            Cvv: "123",
            OwnerFullName: "John Doe",
            ExpirationDate: DateOnly.FromDateTime(DateTime.UtcNow.AddYears(2)),
            CustomerId: 1
        );

        var result = _validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "Number");
    }

    [Theory]
    [InlineData("12")]     // Too short (< 3)
    [InlineData("12345")]  // Too long (> 4)
    public void Validate_InvalidCvv_FailsValidation(string cvv)
    {
        var command = new CreateBankCardCommand(
            Number: "4111111111111111",
            Cvv: cvv,
            OwnerFullName: "John Doe",
            ExpirationDate: DateOnly.FromDateTime(DateTime.UtcNow.AddYears(2)),
            CustomerId: 1
        );

        var result = _validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "Cvv");
    }

    [Fact]
    public void Validate_ExpiredCard_FailsValidation()
    {
        var command = new CreateBankCardCommand(
            Number: "4111111111111111",
            Cvv: "123",
            OwnerFullName: "John Doe",
            ExpirationDate: DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-1)),
            CustomerId: 1
        );

        var result = _validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "ExpirationDate");
    }

    [Fact]
    public void Validate_EmptyOwnerName_FailsValidation()
    {
        var command = new CreateBankCardCommand(
            Number: "4111111111111111",
            Cvv: "123",
            OwnerFullName: "",
            ExpirationDate: DateOnly.FromDateTime(DateTime.UtcNow.AddYears(2)),
            CustomerId: 1
        );

        var result = _validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "OwnerFullName");
    }
}
