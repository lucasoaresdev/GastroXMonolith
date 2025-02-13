// Exemplo simplificado em Program.cs
var builder = WebApplication.CreateBuilder(args);

// Registro dos serviços
builder.Services.AddControllers();
builder.Services.AddApplication();       // Método de extensão para Application
builder.Services.AddInfrastructure(builder.Configuration); // Método de extensão para Infrastructure

// Configuração do Swagger, etc.
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