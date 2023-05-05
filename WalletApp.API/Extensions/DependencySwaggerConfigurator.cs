using Microsoft.OpenApi.Models;

namespace WalletApp.API.Extensions;

public static partial class DependencyСonfigurator
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Wellet App API"
            });
        });
    }

    public static void UseSwaggerBuilder(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseSwagger();

        applicationBuilder.UseSwaggerUI();
    }
}