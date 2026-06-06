using AutoMapper;
using Application.Common.Mappings;
using Application.MediatR.Countries.Queries.Shared;
using Domain.Entities;

namespace Application.MediatR.Cities.Queries.Shared;

public class CityVm : IMapWith<City> {
	public long Id { get; set; }

	public string Name { get; set; } = null!;

	public string Image { get; set; } = null!;

	public double Longitude { get; set; }

	public double Latitude { get; set; }

	public CountryVm Country { get; set; } = null!;



	public void Mapping(Profile profile) {
		profile.CreateMap<City, CityVm>();
	}
}
