using Infrastucture.Interfaces;
using Infrastucture.Repositories;
using Infrastucture.Services;
using SimpleMessenger.Api.Hubs;
using SimpleMessenger.DataAccess.Interfaces;

namespace SimpleMessenger.Api.Extensions;

public static class Startup
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
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

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapHub<MessageHub>("/messageHub");
        });
        return app;
    }
}
