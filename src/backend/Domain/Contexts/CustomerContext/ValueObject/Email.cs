using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Contexts.CustomerContext.ValueObject;

public class Email : GlobalContext.ValueObjects.ValueObject
{
    public Email(string address)
    {
        Address = address;

        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsEmail(Address, "Email.Address", "E-mail inválido")
        );
    }

    public string Address { get; private set; }
    
    public static implicit operator string(Email email)
        => email.ToString();

    public static implicit operator Email(string address)
        => new(address);
}