using Application.Common.Mappings;
using Domain.Entities;

namespace Application.MediatR.RoomTypes.Queries.Shared;

public class RoomTypeVm : IMapWith<RoomType> {
	public long Id { get; set; }

	public string Name { get; set; } = null!;
}
