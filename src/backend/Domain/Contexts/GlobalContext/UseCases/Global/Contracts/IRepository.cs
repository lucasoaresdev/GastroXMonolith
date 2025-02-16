using System.Linq.Expressions;
using Domain.Contexts.GlobalContext.Entities;

namespace Domain.Contexts.GlobalContext.UseCases.Contracts;

public interface IRepository<T> where T : Entity
{
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
}