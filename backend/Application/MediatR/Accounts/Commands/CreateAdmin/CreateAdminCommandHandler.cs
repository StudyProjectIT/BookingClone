using AutoMapper;
using Application.Interfaces;
using Application.Models.Accounts;
using Domain.Constants;
using MediatR;

namespace Application.MediatR.Accounts.Commands.CreateAdmin;

public class CreateAdminCommandHandler(
	IMapper mapper,
	IAuthService authService
) : IRequestHandler<CreateAdminCommand, long> {

	public async Task<long> Handle(CreateAdminCommand request, CancellationToken cancellationToken) {
		var dto = mapper.Map<UserDto>(request);

		var admin = await authService.CreateUserAsync(dto, CreateUserType.Admin, cancellationToken);

		return admin.Id;
	}
}
