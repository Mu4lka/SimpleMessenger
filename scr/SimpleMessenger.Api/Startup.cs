using Infrastucture.Persistence.Repositories;
using SimpleMessenger.Api.Hubs;
using SimpleMessenger.Application.Interfaces;
using SimpleMessenger.Application.Services;
using SimpleMessenger.Domain;

namespace SimpleMessenger.Api;

public static class Startup
{
    public static IServiceCollection ConfigureCors(this IServiceCollection services)
        => services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                builder =>
                {
                    builder
                        .WithOrigins("http://127.0.0.1:5500")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
        });

    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services
            .AddScoped<IMessagesRepository, MessagesRepository>()
            .AddScoped<IMessagesService, MessagesService>();

        return services;
    }
}
