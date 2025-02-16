using Domain.Contexts.CustomerContext.ValueObject;
using Domain.Contexts.GlobalContext.Entities;
using Domain.Contexts.GlobalContext.ValueObjects;

namespace Domain.Contexts.CustomerContext.Entities;

public class Customer : Entity
{
    #region Construtores

    protected Customer() {}
    
    public Customer(Name name, Email email, Address address)
    {
        Name = name;
        Email = email;
        Address = address;
            
        AddNotifications(name, email, address);
    }

    #endregion
    
    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public Address Address { get; private set; }
}