using Application.DTOs;
using Domain.Entities;

namespace Application.Features.Chats;

internal static class ChatMappings
{
    internal static ChatDto MapToDto(Chat e) => new() { Id = e.Id, CustomerId = e.CustomerId, RealtorId = e.RealtorId };
}
