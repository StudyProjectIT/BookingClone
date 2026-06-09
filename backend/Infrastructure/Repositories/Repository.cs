using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class Repository<T>(AppDbContext context) : IRepository<T> where T : class
{
    public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken ct = default) =>
        (await context.Set<T>().ToListAsync(ct)).AsReadOnly();

    public async Task<(IReadOnlyList<T> Items, int TotalCount)> GetPagedAsync(int page, int pageSize, CancellationToken ct = default)
    {
        var query = context.Set<T>();
        var totalCount = await query.CountAsync(ct);
        var items = (await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(ct)).AsReadOnly();
        return (items, totalCount);
    }

    public async Task<T?> GetByIdAsync(long id, CancellationToken ct = default) =>
        await context.Set<T>().FindAsync([id], ct);

    public async Task<T> AddAsync(T entity, CancellationToken ct = default)
    {
        context.Set<T>().Add(entity);
        await context.SaveChangesAsync(ct);
        return entity;
    }

    public async Task UpdateAsync(T entity, CancellationToken ct = default)
    {
        context.Set<T>().Update(entity);
        await context.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(long id, CancellationToken ct = default)
    {
        var entity = await context.Set<T>().FindAsync([id], ct);
        if (entity is not null)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync(ct);
        }
    }
}
