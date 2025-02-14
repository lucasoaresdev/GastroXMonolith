namespace Presentation.Extensions;

public static class AppExtension
{
    public static void UseSwaggerEX(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}