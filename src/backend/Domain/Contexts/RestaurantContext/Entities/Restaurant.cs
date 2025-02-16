namespace Domain.Contexts.GlobalContext.Entities;

public class Restaurant : Entity
{
    protected Restaurant() { }
    
    public Restaurant(string name, string address, string phoneNumber)
    {
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
    }

    public string Name { get; private set; }
    public string Address { get; private set; }
    public string PhoneNumber { get; private set; }
}