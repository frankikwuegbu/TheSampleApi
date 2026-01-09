using Scalar.AspNetCore;
using System.Runtime.CompilerServices;

namespace TheSampleApi.Startup;

public static class OpenApiConfiguration
{
    public static void AddOpenApiServices(this IServiceCollection service)
    {
        service.AddOpenApi();
    }

    public static void UseOpenApi(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference(options =>
            {
                options.Title = "The Sample API";
                options.Theme = ScalarTheme.Saturn;
                options.Layout = ScalarLayout.Modern;
                options.HideClientButton = true;
            });
        }
    }
}
