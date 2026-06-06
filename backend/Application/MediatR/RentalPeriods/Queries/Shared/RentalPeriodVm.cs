using AutoMapper;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.MediatR.RentalPeriods.Queries.Shared;

public class RentalPeriodVm : IMapWith<RentalPeriod> {
	public long Id { get; set; }

	public string Name { get; set; } = null!;



	public void Mapping(Profile profile) {
		profile.CreateMap<RentalPeriod, RentalPeriodVm>();
	}
}
