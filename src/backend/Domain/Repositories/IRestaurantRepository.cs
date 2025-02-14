using Domain.Entities;

namespace Domain.Repositories;

public interface IRestaurantRepository
{
    Task AddAsync(Restaurant restaurant, CancellationToken cancellationToken);
}