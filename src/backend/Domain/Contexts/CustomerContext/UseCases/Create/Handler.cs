using System.Globalization;
using Domain.Contexts.CustomerContext.Entities;
using MediatR;
using Domain.Contexts.CustomerContext.UseCases.Create.Contracts;
using Domain.Contexts.CustomerContext.ValueObject;
using Domain.Contexts.GlobalContext.ValueObjects;
using Flunt.Notifications;

namespace Domain.Contexts.CustomerContext.UseCases.Create;

public class Handler : Notifiable<Notification>, IRequestHandler<Request, Response>
{
    private readonly IRepository _repository;

    public Handler(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response> Handle(Request req, CancellationToken cancellationToken)
    {
        #region 01. Valida a requisição

        try
        {
            var res = Specification.Ensure(req);

            if (!res.IsValid)
                return new Response("Requisição inválida", 400, res.Notifications);
        }
        catch (Exception)
        {
            return new Response("Não foi possível validar sua requisição", 500, null);
        }

        #endregion

        #region 02. Verifica dados existentes

        try
        {
            bool exists = await _repository.ExistsAsync(c => c.Email.Address == req.Email, cancellationToken);

            if (exists)
            {
                return new Response("Já existe um usúario com esse email", 404, Notifications);
            }
        }
        catch (Exception ex)
        {
            return new Response($"Ocorreu uma exceção ao validar email existente {ex.Message}", 500, Notifications);
        }

        #endregion

        #region 03. Define o modelo

        Name name = new Name(req.FirstName, req.LastName);
        Email email = new Email(req.Email);
        Address address = new Address(req.Street, req.Number, req.Neighborhood, req.City, req.State, req.Country,
            req.ZipCode);

        AddNotifications(name, email, address);

        if (!IsValid)
            return new Response("Ocorreu um erro ao definir o modelo", 404, Notifications);

        Customer customer = new Customer(name, email, address);

        #endregion
        
        #region 04. Persiste os dados

        try
        {
            await _repository.AddAsync(customer, cancellationToken);
        }
        catch (Exception ex)
        {
            return new Response($"Ocorreu um erro ao persistir os dados {ex.Message}", 500, Notifications);
        }
        
        #endregion
        
        return new 
            Response("Customer criado com sucesso!", 201, Notifications);
    }
}