using Application.Common.Exceptions;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.MediatR.Accounts.Commands.UnlockUserById;

public class UnlockUserByIdCommandHandler(
	UserManager<AppUser> userManager
) : IRequestHandler<UnlockUserByIdCommand> {

	public async Task Handle(UnlockUserByIdCommand request, CancellationToken cancellationToken) {
		var user = await userManager.FindByIdAsync(request.Id.ToString())
			?? throw new NotFoundException(nameof(AppUser), request.Id);

		user.LockoutEnd = null;

		var result = await userManager.UpdateAsync(user);

		if (!result.Succeeded)
			throw new IdentityException(result);
	}
}
