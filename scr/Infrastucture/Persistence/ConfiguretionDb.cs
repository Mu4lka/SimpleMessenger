using FluentMigrator.Runner;
using Infrastucture.Persistence.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastucture.Persistence;

public static class ConfiguretionDb
{
    /// <summary>
    /// Обновить базу данных
    /// </summary>
    public static void UpdateDatabase(this IServiceProvider provider)
    {
        using var scope = provider.CreateScope();
        var runner = provider.GetRequiredService<IMigrationRunner>();

        runner.MigrateUp();
    }

    /// <summary>
    /// Сконфигурировать миграции
    /// </summary>
    public static IServiceProvider ConfigureMigrations(this IServiceCollection services, IConfiguration configuration)
        => services.AddFluentMigratorCore()
               .ConfigureRunner(rb => rb
                   .AddPostgres()
                   .WithGlobalConnectionString(configuration.GetConnectionString("DefaultConnection")!)
                   .ScanIn(typeof(AddedMessagesTable).Assembly).For.Migrations())
               .AddLogging(lb => lb.AddFluentMigratorConsole())
               .BuildServiceProvider(false);
}
