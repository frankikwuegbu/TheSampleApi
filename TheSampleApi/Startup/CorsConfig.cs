namespace TheSampleApi.Startup;

public static class CorsConfig
{
    private const string AllowAllPolicy = "AllowAll";
    public static void AddCorsServices(this IServiceCollection service)
    {
        service.AddCors(options =>
        {
            options.AddPolicy(AllowAllPolicy, policy =>
            {
            //very permisive cors policy.Not advisable for production environment.
                policy.AllowAnyOrigin();
                policy.AllowAnyMethod();
                policy.AllowAnyHeader();
            });
        });
    }

    public static void ApplyCorsConfig(this WebApplication app)
    {
        app.UseCors(AllowAllPolicy);
    }
}