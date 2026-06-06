using AutoMapper;
using Application.Common.Mappings;
using Application.Models.Address;
using MediatR;

namespace Application.MediatR.Addresses.Commands.Update;

public class UpdateAddressCommand : IRequest, IMapWith<UpdateAddressDto> {
	public long Id { get; set; }

	public string Street { get; set; } = null!;

	public string HouseNumber { get; set; } = null!;

	public int? Floor { get; set; }

	public string? ApartmentNumber { get; set; }

	public long CityId { get; set; }



	public void Mapping(Profile profile) {
		profile.CreateMap<UpdateAddressDto, UpdateAddressCommand>();
	}
}