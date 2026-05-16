using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityTypeConfigurations;

internal class RoomVariantEntityTypeConfiguration : IEntityTypeConfiguration<RoomVariant> {
	public void Configure(EntityTypeBuilder<RoomVariant> builder) {
		builder.ToTable("RoomVariants");
	}
}
