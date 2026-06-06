using MediatR;

namespace Application.MediatR.Accounts.Queries.GetCustomersInformation;

public class GetCustomersInformationCommand : IRequest<CustomersInformationVm> { }
