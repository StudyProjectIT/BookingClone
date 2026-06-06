using Application.Common.Mappings;
using Application.MediatR.BedInfos.Queries.Shared;
using Application.MediatR.GuestInfos.Queries.Shared;
using Domain.Entities;

namespace Application.MediatR.RoomVariants.Queries.Shared;

public class RoomVariantVm : IMapWith<RoomVariant> {
	public long Id { get; set; }

	public decimal Price { get; set; }

	public decimal? DiscountPrice { get; set; }

	public long RoomId { get; set; }

	public GuestInfoVm GuestInfo { get; set; } = null!;

	public BedInfoVm BedInfo { get; set; } = null!;
}
