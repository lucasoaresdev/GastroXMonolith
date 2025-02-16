using Domain.Contexts.CustomerContext.UseCases.Create.Contracts;
using Infrastructure.Contexts.CustomerContext.UseCases.Create;
using MediatR;

namespace Presentation.Extensions;

public static class CustomerExtension
{
    public static void AddCustomerContext(this WebApplicationBuilder builder)
    {
        #region Create

        builder.Services.AddScoped<
            IRepository,
            Repository>();

        #endregion
    }

    public static void MapCustomerEndpoints(this WebApplication app)
    {
        #region Create

        app.MapPost("api/v1/customer/create", async (
            Domain.Contexts.CustomerContext.UseCases.Create.Request request,
            IRequestHandler<
                Domain.Contexts.CustomerContext.UseCases.Create.Request,
                Domain.Contexts.CustomerContext.UseCases.Create.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            if (!result.IsSucess)
                return Results.Json(result, statusCode: result.Status);

            return Results.Ok(result);
        });

        #endregion
    }
}