using Domain.Contexts.CustomerContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Contexts.CustomerContext.Mappings;

public class CustomerMap : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customer");
        
        builder.HasKey(customer => customer.Id);
        
        #region Objetos de Valor (ValueObjects)

        builder.OwnsOne(x => x.Name, nameBuilder =>
        {
            nameBuilder.Property(n => n.FirstName)
                .HasColumnName("FirstName")
                .HasMaxLength(40)
                .IsRequired();

            nameBuilder.Property(n => n.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(40)
                .IsRequired();

            // Opcionalmente, se você quiser uma coluna para o nome completo,
            // pode definir uma coluna computada (caso o seu banco suporte)
            // ou ignorar o FullName:
            nameBuilder.Ignore(n => n.FullName);
        });


        builder.OwnsOne(x => x.Email)
            .Property(x => x.Address)
            .HasColumnName("Email")
            .HasMaxLength(120)
            .IsRequired(true);
        
        builder.OwnsOne(x => x.Address, addressBuilder =>
        {
            addressBuilder.Property(a => a.FullAddress)
                .HasColumnName("Address")
                .IsRequired()
                .HasMaxLength(300);

            // Se não precisar das demais propriedades no banco, ignore-as:
            addressBuilder.Ignore(a => a.Street);
            addressBuilder.Ignore(a => a.Number);
            addressBuilder.Ignore(a => a.Neighborhood);
            addressBuilder.Ignore(a => a.City);
            addressBuilder.Ignore(a => a.State);
            addressBuilder.Ignore(a => a.Country);
            addressBuilder.Ignore(a => a.ZipCode);
        });

        #endregion
    }
}