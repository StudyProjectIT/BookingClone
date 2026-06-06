using AutoMapper;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.MediatR.Breakfasts.Queries.Shared;

public class BreakfastVm : IMapWith<Breakfast> {
	public long Id { get; set; }

	public string Name { get; set; } = null!;



	public void Mapping(Profile profile) {
		profile.CreateMap<Breakfast, BreakfastVm>();
	}
}
