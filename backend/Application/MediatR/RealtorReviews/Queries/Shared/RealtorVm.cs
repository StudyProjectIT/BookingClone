using Application.Common.Mappings;
using Domain.Entities.Identity;

namespace Application.MediatR.RealtorReviews.Queries.Shared;

public class RealtorVm : IMapWith<Realtor> {
	public long Id { get; set; }

	public string UserName { get; set; } = null!;

	public string FirstName { get; set; } = null!;

	public string LastName { get; set; } = null!;

	public string Photo { get; set; } = null!;
}
