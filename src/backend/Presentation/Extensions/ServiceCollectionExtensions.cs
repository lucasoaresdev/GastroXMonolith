namespace Presentation.Extensions;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Aqui você pode registrar serviços específicos da camada Presentation.
        // Por exemplo, se precisar configurar um DbContext, ficaria algo assim:
        //
        // services.AddDbContext<YourDbContext>(options =>
        //     options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        //
        // Ou registrar outros serviços que a camada possa necessitar.

        return services;
    }
}