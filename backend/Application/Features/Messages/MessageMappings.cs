using Application.DTOs;
using Domain.Entities;

namespace Application.Features.Messages;

internal static class MessageMappings
{
    internal static MessageDto MapToDto(Message e) => new()
    {
        Id = e.Id,
        Text = e.Text,
        ChatId = e.ChatId,
        AuthorId = e.AuthorId,
        CreatedAtUtc = e.CreatedAtUtc,
        UpdatedAtUtc = e.UpdatedAtUtc
    };
}
