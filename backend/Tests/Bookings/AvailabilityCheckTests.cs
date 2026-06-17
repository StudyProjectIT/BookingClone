using FluentAssertions;
using Infrastructure.Repositories;
using Tests.Fixtures;
using Tests.Helpers;

namespace Tests.Bookings;

[Collection("Database")]
public class AvailabilityCheckTests(DatabaseFixture fixture) : IAsyncLifetime
{
    private Infrastructure.Data.AppDbContext _ctx = null!;

    public async Task InitializeAsync() => _ctx = fixture.CreateContext();
    public async Task DisposeAsync() => await _ctx.DisposeAsync();

    [Fact]
    public async Task IsAvailable_WhenNoBookings_ReturnsTrue()
    {
        var (_, variant) = await SeedHelper.SeedBookingChainAsync(_ctx);
        var repo = new BookingRepository(_ctx);

        var result = await repo.IsRoomVariantAvailableAsync(
            variant.Id,
            new DateOnly(2027, 1, 10),
            new DateOnly(2027, 1, 15),
            null);

        result.Should().BeTrue();
    }

    [Fact]
    public async Task IsAvailable_WhenDatesOverlap_ReturnsFalse()
    {
        var (customer, variant) = await SeedHelper.SeedBookingChainAsync(_ctx);
        var repo = new BookingRepository(_ctx);

        await SeedHelper.SeedBookingAsync(_ctx, customer.Id, variant.Id,
            new DateOnly(2027, 2, 10),
            new DateOnly(2027, 2, 20));

        // Overlaps: starts before existing ends, ends after existing starts
        var result = await repo.IsRoomVariantAvailableAsync(
            variant.Id,
            new DateOnly(2027, 2, 15),
            new DateOnly(2027, 2, 25),
            null);

        result.Should().BeFalse();
    }

    [Fact]
    public async Task IsAvailable_WhenExcludingOwnBooking_ReturnsTrue()
    {
        var (customer, variant) = await SeedHelper.SeedBookingChainAsync(_ctx);
        var repo = new BookingRepository(_ctx);

        var booking = await SeedHelper.SeedBookingAsync(_ctx, customer.Id, variant.Id,
            new DateOnly(2027, 3, 10),
            new DateOnly(2027, 3, 20));

        // Same dates but excluding the booking itself (update scenario)
        var result = await repo.IsRoomVariantAvailableAsync(
            variant.Id,
            new DateOnly(2027, 3, 10),
            new DateOnly(2027, 3, 20),
            booking.Id);

        result.Should().BeTrue();
    }

    [Fact]
    public async Task IsAvailable_WhenAdjacentDates_ReturnsTrue()
    {
        var (customer, variant) = await SeedHelper.SeedBookingChainAsync(_ctx);
        var repo = new BookingRepository(_ctx);

        await SeedHelper.SeedBookingAsync(_ctx, customer.Id, variant.Id,
            new DateOnly(2027, 4, 10),
            new DateOnly(2027, 4, 15));

        // Check-in exactly when previous checks out — no overlap
        var result = await repo.IsRoomVariantAvailableAsync(
            variant.Id,
            new DateOnly(2027, 4, 15),
            new DateOnly(2027, 4, 20),
            null);

        result.Should().BeTrue();
    }
}
