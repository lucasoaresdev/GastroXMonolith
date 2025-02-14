using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Restaurants.Commands;

public class RegisterRestaurantCommandHandler : IRequestHandler<RegisterRestaurantCommand, Guid>
{
    private readonly IRestaurantRepository _repository;

    public RegisterRestaurantCommandHandler(IRestaurantRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(RegisterRestaurantCommand command, CancellationToken cancellationToken)
    {
        // Cria a entidade utilizando o comando recebido
        var restaurant = new Restaurant(command.Name, command.Address, command.PhoneNumber);
            
        // Salva o restaurante através do repositório (a implementação virá na camada Infrastructure)
        await _repository.AddAsync(restaurant, cancellationToken);
            
        // Retorna o ID gerado (supondo que o repositório defina o Id)
        return restaurant.Id;
    }
}