// Licensed to the Rapture Project under one or more agreements.
// The Rapture Project licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore;
using Rapture.Database.Entities.Patching;

namespace Rapture.Database;

/// <summary>
/// The application database context.
/// </summary>
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    /// <summary>
    /// The patch platforms.
    /// </summary>
    public DbSet<PatchPlatform> PatchPlatforms => Set<PatchPlatform>();

    /// <summary>
    /// The patch channels.
    /// </summary>
    public DbSet<PatchChannel> PatchChannels => Set<PatchChannel>();

    /// <summary>
    /// The patch types.
    /// </summary>
    public DbSet<PatchType> PatchTypes => Set<PatchType>();

    /// <summary>
    /// The patch repositories.
    /// </summary>
    public DbSet<PatchRepository> PatchRepositories => Set<PatchRepository>();

    /// <summary>
    /// The patch versions.
    /// </summary>
    public DbSet<PatchVersion> PatchVersions => Set<PatchVersion>();

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("citext");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    /// <inheritdoc/>
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>()
            .HaveColumnType("citext");
    }
}
