using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Contexts.CustomerContext.ValueObject;

public class Name : GlobalContext.ValueObjects.ValueObject
{
    // Construtor público para uso na lógica de negócio
    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        FullName = $"{firstName} {lastName}";
            
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsGreaterThan(FirstName, 3, "Name.FirstName", "Nome deve conter pelo menos 3 caracteres")
            .IsGreaterThan(LastName, 3, "Name.LastName", "Sobrenome deve conter pelo menos 3 caracteres")
            .IsLowerThan(FirstName, 40, "Name.FirstName", "Nome deve conter até 40 caracteres")
        );
    }

    // Construtor sem parâmetros para o EF Core
    protected Name() { }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
        
    // Agora com setter privado para permitir que o EF Core faça o mapeamento
    public string FullName { get; private set; }
        
    public override string ToString() => FullName;
}