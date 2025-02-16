using Domain.Contexts.CustomerContext.Entities;
using Domain.Contexts.GlobalContext.UseCases.Contracts;

namespace Domain.Contexts.CustomerContext.UseCases.Create.Contracts;

public interface IRepository : IRepository<Customer>
{
    Task AddAsync(Customer customer, CancellationToken cancellationToken = default);
}