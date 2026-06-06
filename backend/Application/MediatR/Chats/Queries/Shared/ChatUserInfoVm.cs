using AutoMapper;
using Application.Common.Mappings;
using Domain.Entities.Identity;

namespace Application.MediatR.Chats.Queries.Shared;

public class ChatUserInfoVm : IMapWith<AppUser> {
	public string FullName { get; set; } = null!;

	public string Photo { get; set; } = null!;



	public void Mapping(Profile profile) {
		profile.CreateMap<AppUser, ChatUserInfoVm>()
			.ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
	}
}
