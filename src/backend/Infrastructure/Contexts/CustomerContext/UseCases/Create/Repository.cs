using Domain.Contexts.CustomerContext.Entities;
using Domain.Contexts.CustomerContext.UseCases.Create.Contracts;
using Infrastructure.Contexts.GlobalContext.UseCases.Global;
using Infrastructure.Data;

namespace Infrastructure.Contexts.CustomerContext.UseCases.Create;

public class Repository : Repository<Customer>, IRepository
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task AddAsync(Customer customer, CancellationToken cancellationToken = default)
    {
        await _context.Customers.AddAsync(customer, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}