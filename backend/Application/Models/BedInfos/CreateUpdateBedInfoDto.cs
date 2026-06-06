using AutoMapper;
using Application.Common.Mappings;
using Application.MediatR.BedInfos.Commands.Create;
using Application.MediatR.BedInfos.Commands.Update;

namespace Application.Models.BedInfos;

public class CreateUpdateBedInfoDto : IMapWith<CreateBedInfoCommand>, IMapWith<UpdateBedInfoCommand> {
	public int SingleBedCount { get; set; }

	public int DoubleBedCount { get; set; }

	public int ExtraBedCount { get; set; }

	public int SofaCount { get; set; }

	public int KingsizeBedCount { get; set; }



	public void Mapping(Profile profile) {
		profile.CreateMap<CreateUpdateBedInfoDto, CreateBedInfoCommand>();
		profile.CreateMap<CreateUpdateBedInfoDto, UpdateBedInfoCommand>();
	}
}
