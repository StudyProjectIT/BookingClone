using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RoomVariantRepository(AppDbContext context) : Repository<RoomVariant>(context), IRoomVariantRepository
{
    private IQueryable<RoomVariant> WithIncludes() =>
        Context.RoomVariants
            .Include(v => v.GuestInfo)
            .Include(v => v.BedInfo);

    public override async Task<IReadOnlyList<RoomVariant>> GetAllAsync(CancellationToken ct = default) =>
        (await WithIncludes().AsNoTracking().ToListAsync(ct)).AsReadOnly();

    public override async Task<(IReadOnlyList<RoomVariant> Items, int TotalCount)> GetPagedAsync(int page, int pageSize, CancellationToken ct = default)
    {
        var query = WithIncludes().AsNoTracking();
        var totalCount = await query.CountAsync(ct);
        var items = (await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(ct)).AsReadOnly();
        return (items, totalCount);
    }

    // No AsNoTracking — entity may be used for update
    public override async Task<RoomVariant?> GetByIdAsync(long id, CancellationToken ct = default) =>
        await WithIncludes().FirstOrDefaultAsync(v => v.Id == id, ct);

    public async Task<IReadOnlyList<RoomVariant>> GetByRoomIdAsync(long roomId, CancellationToken ct = default) =>
        (await WithIncludes().AsNoTracking().Where(v => v.RoomId == roomId).ToListAsync(ct)).AsReadOnly();
}
