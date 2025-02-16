using System.Linq.Expressions;
using Domain.Contexts.GlobalContext.Entities;
using Domain.Contexts.GlobalContext.UseCases.Contracts;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts.GlobalContext.UseCases.Global;

public class Repository<T> : IRepository<T> where T : Entity
{
    protected readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().AnyAsync(predicate, cancellationToken);
    }
}