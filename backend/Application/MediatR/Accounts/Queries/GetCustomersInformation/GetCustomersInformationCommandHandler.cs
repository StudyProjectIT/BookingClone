using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.MediatR.Accounts.Queries.GetCustomersInformation;

public class GetCustomersInformationCommandHandler(
	ICurrentUserService currentUserService,
	UserManager<AppUser> userManager,
	IMapper mapper
) : IRequestHandler<GetCustomersInformationCommand, CustomersInformationVm> {

	public async Task<CustomersInformationVm> Handle(GetCustomersInformationCommand request, CancellationToken cancellationToken) {
		return await userManager.Users
			.AsNoTracking()
			.OfType<Customer>()
			.Where(с => с.Id == currentUserService.GetRequiredUserId())
			.ProjectTo<CustomersInformationVm>(mapper.ConfigurationProvider)
			.FirstOrDefaultAsync(cancellationToken)
			?? throw new NotFoundException(nameof(Customer), currentUserService.GetRequiredUserId());
	}
}
