using Application.Common.Mappings;
using Domain.Entities;

namespace Application.MediatR.RoomAmenities.Queries.Shared;

public class RoomAmenityVm : IMapWith<RoomAmenity> {
	public long Id { get; set; }

	public string Name { get; set; } = null!;
}
