using Domain.Contexts.CustomerContext.Entities;
using Domain.Contexts.GlobalContext.Entities;
using Flunt.Notifications;
using Infrastructure.Contexts.CustomerContext.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        
    }

    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<Notification>();
        
        modelBuilder.ApplyConfiguration(new CustomerMap());
        
        base.OnModelCreating(modelBuilder);
    }
}