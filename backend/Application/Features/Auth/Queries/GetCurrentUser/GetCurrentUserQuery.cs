using Application.DTOs.Auth;
using Domain.Common;
using MediatR;

namespace Application.Features.Auth.Queries.GetCurrentUser;

public record GetCurrentUserQuery(long UserId) : IRequest<Result<UserDto>>;
