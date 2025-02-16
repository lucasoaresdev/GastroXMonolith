using MediatR;

namespace Domain.Contexts.CustomerContext.UseCases.Create;

public record Request(
    string FirstName,
    string LastName,
    string Email,
    string Street,
    string Number,
    string Neighborhood,
    string City,
    string State,
    string Country,
    string ZipCode
) : IRequest<Response>;