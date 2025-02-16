using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Contexts.CustomerContext.UseCases.Create;

public class Specification
{
    public static Contract<Notification> Ensure(Request request)
        => new Contract<Notification>()
            .Requires()
            .IsGreaterThan(request.FirstName, 3, "Name.request.FirstName", "Nome deve conter pelo menos 3 caracteres")
            .IsGreaterThan(request.LastName, 3, "Name.request.LastName", "Sobrenome deve conter pelo menos 3 caracteres")
            .IsLowerThan(request.FirstName, 40, "Name.request.FirstName", "Nome deve conter até 40 caracteres")
            .IsEmail(request.Email, "Email.Address", "E-mail inválido")
            .IsGreaterThan(request.Street, 3, "Address.Street", "O nome da rua deve conter pelo menos 3 caracteres")
            .AreEquals(request.ZipCode.Length, 8, "Address.ZipCode", "O cep deve conter 8 caracteres");
}