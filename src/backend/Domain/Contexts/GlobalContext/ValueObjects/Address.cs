using System.ComponentModel.DataAnnotations.Schema;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Contexts.GlobalContext.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string street, string number, string neighborhood, string city, string state, string country, string zipCode)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;

            FullAddress = $"{Street}, {Number}, {Neighborhood}, {City}, {State}, {Country}, {ZipCode}";

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsGreaterThan(Street, 3, "Address.Street", "O nome da rua deve conter pelo menos 3 caracteres")
                .AreEquals(ZipCode.Length, 8, "Address.ZipCode", "O CEP deve conter 8 caracteres")
            );
        }

        // Construtor sem parâmetros para o EF Core
        protected Address() { }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }

        // Adicione o setter privado para que o EF Core consiga atribuir o valor
        public string FullAddress { get; private set; }

        public override string ToString() => FullAddress;
    }
}