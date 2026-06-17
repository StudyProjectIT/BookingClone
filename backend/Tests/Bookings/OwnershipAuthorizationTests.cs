using Application.Features.BankCards.Commands.DeleteBankCard;
using Application.Features.Bookings.Commands.DeleteBooking;
using Application.Interfaces;
using Domain.Entities;
using FluentAssertions;
using Infrastructure.Repositories;
using Moq;
using Tests.Fixtures;
using Tests.Helpers;

namespace Tests.Bookings;

[Collection("Database")]
public class OwnershipAuthorizationTests(DatabaseFixture fixture) : IAsyncLifetime
{
    private Infrastructure.Data.AppDbContext _ctx = null!;

    public async Task InitializeAsync() => _ctx = fixture.CreateContext();
    public async Task DisposeAsync() => await _ctx.DisposeAsync();

    [Fact]
    public async Task DeleteBooking_ByOwner_Succeeds()
    {
        var (customer, variant) = await SeedHelper.SeedBookingChainAsync(_ctx);
        var booking = await SeedHelper.SeedBookingAsync(_ctx, customer.Id, variant.Id,
            new DateOnly(2027, 8, 1), new DateOnly(2027, 8, 5));

        var currentUser = new Mock<ICurrentUserService>();
        currentUser.Setup(x => x.GetUserId()).Returns(customer.Id);

        var repo = new BookingRepository(_ctx);
        var handler = new DeleteBookingHandler(repo, currentUser.Object);

        var result = await handler.Handle(new DeleteBookingCommand(booking.Id), CancellationToken.None);

        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task DeleteBooking_ByOtherUser_ReturnsForbidden()
    {
        var (customer, variant) = await SeedHelper.SeedBookingChainAsync(_ctx);
        var booking = await SeedHelper.SeedBookingAsync(_ctx, customer.Id, variant.Id,
            new DateOnly(2027, 9, 1), new DateOnly(2027, 9, 5));

        var currentUser = new Mock<ICurrentUserService>();
        currentUser.Setup(x => x.GetUserId()).Returns(99999L); // Інший юзер

        var repo = new BookingRepository(_ctx);
        var handler = new DeleteBookingHandler(repo, currentUser.Object);

        var result = await handler.Handle(new DeleteBookingCommand(booking.Id), CancellationToken.None);

        result.IsSuccess.Should().BeFalse();
        result.Error.Code.Should().Be("Forbidden");
    }

    [Fact]
    public async Task DeleteBooking_NotFound_ReturnsNotFound()
    {
        var currentUser = new Mock<ICurrentUserService>();
        currentUser.Setup(x => x.GetUserId()).Returns(1L);

        var repo = new BookingRepository(_ctx);
        var handler = new DeleteBookingHandler(repo, currentUser.Object);

        var result = await handler.Handle(new DeleteBookingCommand(999999), CancellationToken.None);

        result.IsSuccess.Should().BeFalse();
        result.Error.Code.Should().Be("NotFound");
    }

    [Fact]
    public async Task DeleteBankCard_ByOtherUser_ReturnsForbidden()
    {
        var card = new BankCard
        {
            Number = "4111111111111111",
            Cvv = "123",
            OwnerFullName = "Test User",
            ExpirationDate = DateOnly.FromDateTime(DateTime.UtcNow.AddYears(2)),
            CustomerId = 1
        };
        _ctx.BankCards.Add(card);
        await _ctx.SaveChangesAsync();

        var currentUser = new Mock<ICurrentUserService>();
        currentUser.Setup(x => x.GetUserId()).Returns(99999L); // Інший юзер

        var repo = new Repository<BankCard>(_ctx);
        var handler = new DeleteBankCardHandler(repo, currentUser.Object);

        var result = await handler.Handle(new DeleteBankCardCommand(card.Id), CancellationToken.None);

        result.IsSuccess.Should().BeFalse();
        result.Error.Code.Should().Be("Forbidden");
    }
}
