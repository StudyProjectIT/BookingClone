using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AddressRepository(AppDbContext context) : Repository<Address>(context), IAddressRepository
{
    private IQueryable<Address> WithIncludes() =>
        Context.Addresses.Include(a => a.City).ThenInclude(c => c.Country);

    public override async Task<IReadOnlyList<Address>> GetAllAsync(CancellationToken ct = default) =>
        (await WithIncludes().ToListAsync(ct)).AsReadOnly();

    public override async Task<(IReadOnlyList<Address> Items, int TotalCount)> GetPagedAsync(int page, int pageSize, CancellationToken ct = default)
    {
        var query = WithIncludes();
        var totalCount = await query.CountAsync(ct);
        var items = (await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(ct)).AsReadOnly();
        return (items, totalCount);
    }

    public override async Task<Address?> GetByIdAsync(long id, CancellationToken ct = default) =>
        await WithIncludes().FirstOrDefaultAsync(a => a.Id == id, ct);
}