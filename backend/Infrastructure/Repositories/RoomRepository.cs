using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RoomRepository(AppDbContext context) : IRoomRepository
{
    public async Task<IReadOnlyList<Room>> GetByHotelIdAsync(long hotelId, CancellationToken ct = default)
    {
        return (await context.Rooms
            .Where(r => r.HotelId == hotelId)
            .Include(r => r.RoomType)
            .ToListAsync(ct))
            .AsReadOnly();
    }

    public async Task<Room?> GetByIdAsync(long id, CancellationToken ct = default)
    {
        return await context.Rooms
            .Include(r => r.RoomType)
            .FirstOrDefaultAsync(r => r.Id == id, ct);
    }

    public async Task<Room> AddAsync(Room room, CancellationToken ct = default)
    {
        context.Rooms.Add(room);
        await context.SaveChangesAsync(ct);
        return room;
    }

    public async Task UpdateAsync(Room room, CancellationToken ct = default)
    {
        context.Rooms.Update(room);
        await context.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(long id, CancellationToken ct = default)
    {
        var room = await context.Rooms.FindAsync(new object[] { id }, ct);
        if (room is not null)
        {
            context.Rooms.Remove(room);
            await context.SaveChangesAsync(ct);
        }
    }
}
