using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class Repository<T>(AppDbContext context) : IRepository<T> where T : class
{
    protected AppDbContext Context { get; } = context;

    public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken ct = default) =>
        (await Context.Set<T>().ToListAsync(ct)).AsReadOnly();

    public async Task<(IReadOnlyList<T> Items, int TotalCount)> GetPagedAsync(int page, int pageSize, CancellationToken ct = default)
    {
        var query = Context.Set<T>();
        var totalCount = await query.CountAsync(ct);
        var items = (await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(ct)).AsReadOnly();
        return (items, totalCount);
    }

    public async Task<T?> GetByIdAsync(long id, CancellationToken ct = default) =>
        await Context.Set<T>().FindAsync([id], ct);

    public async Task<T> AddAsync(T entity, CancellationToken ct = default)
    {
        Context.Set<T>().Add(entity);
        await Context.SaveChangesAsync(ct);
        return entity;
    }

    public async Task UpdateAsync(T entity, CancellationToken ct = default)
    {
        Context.Set<T>().Update(entity);
        await Context.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(long id, CancellationToken ct = default)
    {
        var entity = await Context.Set<T>().FindAsync([id], ct);
        if (entity is not null)
        {
            Context.Set<T>().Remove(entity);
            await Context.SaveChangesAsync(ct);
        }
    }
}
