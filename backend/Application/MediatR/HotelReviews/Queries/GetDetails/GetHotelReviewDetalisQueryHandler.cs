using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Common.Exceptions;
using Application.Interfaces;
using Application.MediatR.HotelReviews.Queries.Shared;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MediatR.HotelReviews.Queries.GetDetails;

public class GetHotelReviewDetalisQueryHandler(
	IBookingDbContext context,
	IMapper mapper
) : IRequestHandler<GetHotelReviewDetalisQuery, HotelReviewVm> {

	public async Task<HotelReviewVm> Handle(GetHotelReviewDetalisQuery request, CancellationToken cancellationToken) {
		var vm = await context.HotelReviews
			.ProjectTo<HotelReviewVm>(mapper.ConfigurationProvider)
			.FirstOrDefaultAsync(hr => hr.Id == request.Id, cancellationToken)
			?? throw new NotFoundException(nameof(HotelReview), request.Id);

		return vm;
	}
}
