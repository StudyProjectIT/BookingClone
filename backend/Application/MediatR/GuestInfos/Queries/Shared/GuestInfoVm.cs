using Application.Common.Mappings;
using Domain.Entities;

namespace Application.MediatR.GuestInfos.Queries.Shared;

public class GuestInfoVm : IMapWith<GuestInfo> {
	public int AdultCount { get; set; }

	public int ChildCount { get; set; }
}
