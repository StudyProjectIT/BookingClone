using AutoMapper;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.MediatR.Accounts.Queries.GetRealtorsInformation;

public class RealtorsInformationCitizenshipVm : IMapWith<Citizenship> {
	public long Id { get; set; }

	public string Name { get; set; } = null!;



	public void Mapping(Profile profile) {
		profile.CreateMap<Citizenship, RealtorsInformationCitizenshipVm>();
	}
}
