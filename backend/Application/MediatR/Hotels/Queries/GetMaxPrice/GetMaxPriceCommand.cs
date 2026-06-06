using MediatR;

namespace Application.MediatR.Hotels.Queries.GetMaxPrice;

public class GetMaxPriceCommand : IRequest<decimal?> { }
