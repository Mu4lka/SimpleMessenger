using Infrastucture.Interfaces;
using Infrastucture.Repositories;
using Infrastucture.Services;
using SimpleMessenger.Api.Hubs;
using SimpleMessenger.DataAccess.Interfaces;

namespace SimpleMessenger.Api.Extensions;

public static class Startup
{
    public static IServiceCollection ConfigureCors(this IServiceCollection services)
        => services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                builder =>
                {
                    builder
                        .WithOrigins("http://127.0.0.1:5500")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
        });

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services
            .AddScoped<IMessagesRepository, MessagesRepository>()
            .AddScoped<IMessagesService, MessagesService>()
            .AddSignalR();

        return services;
    }

    public static IApplicationBuilder ConfigureHub(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseCors("AllowSpecificOrigin");

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapHub<MessageHub>("/messageHub");
        });

        return app;
    }
}
