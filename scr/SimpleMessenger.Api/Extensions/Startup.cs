using SimpleMessenger.Api.Hubs;

namespace SimpleMessenger.Api.Extensions;

public static class Startup
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddSignalR();
        return services;
    }

    public static IApplicationBuilder Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
