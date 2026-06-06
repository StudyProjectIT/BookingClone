using AutoMapper;
using Application.Common.Mappings;
using Application.MediatR.GuestInfos.Commands.Create;
using Application.MediatR.GuestInfos.Commands.Update;

namespace Application.Models.GuestInfos;

public class CreateUpdateGuestInfoDto : IMapWith<CreateGuestInfoCommand>, IMapWith<UpdateGuestInfoCommand> {
	public int AdultCount { get; set; }

	public int ChildCount { get; set; }



	public void Mapping(Profile profile) {
		profile.CreateMap<CreateUpdateGuestInfoDto, CreateGuestInfoCommand>();
		profile.CreateMap<CreateUpdateGuestInfoDto, UpdateGuestInfoCommand>();
	}
}
