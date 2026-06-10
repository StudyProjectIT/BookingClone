using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IRoomVariantRepository : IRepository<RoomVariant>
{
    Task<IReadOnlyList<RoomVariant>> GetByRoomIdAsync(long roomId, CancellationToken ct = default);
}
