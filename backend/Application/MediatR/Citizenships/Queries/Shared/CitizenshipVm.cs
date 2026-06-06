using Application.Common.Mappings;
using Domain.Entities;

namespace Application.MediatR.Citizenships.Queries.Shared;

public class CitizenshipVm : IMapWith<Citizenship> {
	public long Id { get; set; }

	public string Name { get; set; } = null!;
}
