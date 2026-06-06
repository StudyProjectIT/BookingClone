using AutoMapper;
using Application.Common.Mappings;
using Domain.Entities.Identity;

namespace Application.MediatR.Hotels.Queries.Shared;

public class RealtorShortInfoVm : IMapWith<Realtor> {
	public long Id { get; set; }

	public string FirstName { get; set; } = null!;



	public void Mapping(Profile profile) {
		profile.CreateMap<Realtor, RealtorShortInfoVm>();
	}
}
