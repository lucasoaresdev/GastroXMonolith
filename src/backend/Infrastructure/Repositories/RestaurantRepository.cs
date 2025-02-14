using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class RestaurantRepository : IRestaurantRepository
{
    private readonly AppDbContext _context;

    public RestaurantRepository(AppDbContext context)
        => _context = context;
    
    public async Task AddAsync(Restaurant restaurant, CancellationToken cancellationToken)
        => await _context.Restaurants.AddAsync(restaurant, cancellationToken);
}