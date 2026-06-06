using AutoMapper;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.MediatR.Languages.Queries.Shared;

public class LanguageVm : IMapWith<Language> {
	public long Id { get; set; }

	public string Name { get; set; } = null!;



	public void Mapping(Profile profile) {
		profile.CreateMap<Language, LanguageVm>();
	}
}
