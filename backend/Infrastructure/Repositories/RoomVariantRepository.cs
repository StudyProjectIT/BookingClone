using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RoomVariantRepository(AppDbContext context) : Repository<RoomVariant>(context), IRoomVariantRepository
{
    public async Task<IReadOnlyList<RoomVariant>> GetByRoomIdAsync(long roomId, CancellationToken ct = default) =>
        (await Context.RoomVariants.Where(v => v.RoomId == roomId).ToListAsync(ct)).AsReadOnly();
}
