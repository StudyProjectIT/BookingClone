using Application.Interfaces;
using Application.Models.Pagination;
using MediatR;

namespace Application.MediatR.Accounts.Queries.GetCustomerPage;

public class GetCustomerPageCommandHandler(
	IPaginationService<CustomerItemVm, GetCustomerPageCommand> paginationService
) : IRequestHandler<GetCustomerPageCommand, PageVm<CustomerItemVm>> {

	public Task<PageVm<CustomerItemVm>> Handle(GetCustomerPageCommand request, CancellationToken cancellationToken) =>
		paginationService.GetPageAsync(request, cancellationToken);
}
