using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation.Extensions; // Namespace da classe de extensão que criamos

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços para os controllers
builder.Services.AddControllers();

builder.AddConfiguration();
builder.AddDatabase();
builder.AddJwtAuthentication();
builder.AddMediator();
builder.AddSwagger();

var app = builder.Build();

app.UseSwaggerEX();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();