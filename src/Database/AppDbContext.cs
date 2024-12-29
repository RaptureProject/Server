// Licensed to the Rapture Project under one or more agreements.
// The Rapture Project licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore;

namespace Rapture.Database;

/// <summary>
/// The application database context.
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    /// Creates a <see cref="AppDbContext"/> instance.
    /// </summary>
    /// <param name="options">The <see cref="DbContextOptions{TContext}"/> to use.</param>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("citext");
    }

    /// <inheritdoc/>
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>()
            .HaveColumnType("citext");
    }
}
