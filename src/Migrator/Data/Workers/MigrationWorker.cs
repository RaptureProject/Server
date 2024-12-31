// Licensed to the Rapture Project under one or more agreements.
// The Rapture Project licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Rapture.Database;

namespace Rapture.Migrator.Data.Workers;

/// <summary>
/// A worker service that handles data migrations.
/// </summary>
public partial class MigrationWorker : BackgroundService
{
    private readonly ILogger<MigrationWorker> _logger;
    private readonly IServiceProvider _serviceProvider;
    private readonly IHostApplicationLifetime _hostApplicationLifetime;

    [LoggerMessage(0, LogLevel.Information, "Migrating database...")]
    private static partial void LogMigrationStarting(ILogger logger);

    [LoggerMessage(1, LogLevel.Error, "Migrating database failed!")]
    private static partial void LogMigrationFailed(ILogger logger, Exception exception);

    /// <summary>
    /// Creates a <see cref="MigrationWorker"/> instance.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger{TCategoryName}"/>.</param>
    /// <param name="serviceProvider">The <see cref="IServiceProvider"/>.</param>
    /// <param name="hostApplicationLifetime">The <see cref="IHostApplicationLifetime"/>.</param>
    public MigrationWorker(
        ILogger<MigrationWorker> logger,
        IServiceProvider serviceProvider,
        IHostApplicationLifetime hostApplicationLifetime)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
        _hostApplicationLifetime = hostApplicationLifetime;
    }

    /// <inheritdoc/>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        LogMigrationStarting(_logger);

        try
        {
            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            await EnsureDatabaseCreatedAsync(dbContext, stoppingToken);
            await MigrateDatabaseAsync(dbContext, stoppingToken);
        }
        catch (Exception ex)
        {
            LogMigrationFailed(_logger, ex);
            throw;
        }

        _hostApplicationLifetime.StopApplication();
    }

    private static async Task EnsureDatabaseCreatedAsync(AppDbContext dbContext, CancellationToken cancellationToken)
    {
        var dbCreator = dbContext.GetService<IRelationalDatabaseCreator>();
        var strategy = dbContext.Database.CreateExecutionStrategy();

        await strategy.ExecuteAsync(async () =>
        {
            if (!await dbCreator.ExistsAsync(cancellationToken))
            {
                await dbCreator.CreateAsync(cancellationToken);
            }
        });
    }

    private static async Task MigrateDatabaseAsync(AppDbContext dbContext, CancellationToken cancellationToken)
    {
        var strategy = dbContext.Database.CreateExecutionStrategy();

        await strategy.ExecuteAsync(async () =>
        {
            await dbContext.Database.MigrateAsync(cancellationToken);
        });
    }
}
