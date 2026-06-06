using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MediatR.HotelReviews.Commands.Delete;

public class DeleteHotelReviewCommandHandler(
	IBookingDbContext context,
	ICurrentUserService currentUserService
) : IRequestHandler<DeleteHotelReviewCommand> {

	public async Task Handle(DeleteHotelReviewCommand request, CancellationToken cancellationToken) {
		var entity = await context.HotelReviews
			.FirstOrDefaultAsync(
				hr => hr.Id == request.Id && hr.Booking.CustomerId == currentUserService.GetRequiredUserId(),
				cancellationToken
			)
			?? throw new NotFoundException(nameof(HotelReview), request.Id);

		context.HotelReviews.Remove(entity);
		await context.SaveChangesAsync(cancellationToken);
	}
}
