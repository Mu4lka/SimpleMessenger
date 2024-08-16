using FluentMigrator.Runner;
using Infrastucture.Persistence.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastucture.Persistence;

public static class ConfiguretionDb
{
    public static IServiceCollection UpdateDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var provider = services.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddPostgres()
                    .WithGlobalConnectionString(configuration.GetConnectionString("DefaultConnection")!)
                    .ScanIn(typeof(AddedMessagesTable).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);

        using var scope = provider.CreateScope();
        var runner = provider.GetRequiredService<IMigrationRunner>();

        runner.MigrateUp();
        return services;
    }
}
