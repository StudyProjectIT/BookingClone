using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityTypeConfigurations;

internal class BookingEntityTypeConfiguration : IEntityTypeConfiguration<Booking> {
	public void Configure(EntityTypeBuilder<Booking> builder) {
		builder.ToTable("Bookings");

		builder.Property(b => b.PersonalWishes)
			.HasMaxLength(4000)
			.IsRequired(false);

		builder.Property(b => b.Status)
			.HasConversion<string>()
			.HasMaxLength(20)
			.HasDefaultValue(BookingStatus.Pending)
			.IsRequired();

		builder.Property(b => b.CancelledAtUtc).IsRequired(false);
		builder.Property(b => b.ConfirmedAtUtc).IsRequired(false);
	}
}
