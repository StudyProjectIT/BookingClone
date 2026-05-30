using Application.DTOs.Auth;
using Domain.Common;
using MediatR;

namespace Application.Features.Auth.Commands.UpdateProfile;

public record UpdateProfileCommand(long UserId, ProfileUpdateDto Dto) : IRequest<Result<UserDto>>;
