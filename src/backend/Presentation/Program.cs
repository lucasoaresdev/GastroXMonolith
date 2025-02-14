using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation.Extensions; // Namespace da classe de extensão que criamos

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços para os controllers
builder.Services.AddControllers();

// Registra os serviços específicos da camada de Presentation
builder.Services.AddPresentationServices(builder.Configuration);

// Configura o Swagger para documentação da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();