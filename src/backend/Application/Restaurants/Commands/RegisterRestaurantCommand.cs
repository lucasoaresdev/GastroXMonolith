using MediatR;

namespace Application.Restaurants.Commands;

// O comando que será enviado para registrar um novo restaurante
public class RegisterRestaurantCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
}