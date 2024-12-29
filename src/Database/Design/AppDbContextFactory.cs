// Licensed to the Rapture Project under one or more agreements.
// The Rapture Project licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Rapture.Database.Design;

/// <summary>
/// A factory for creating <see cref="AppDbContext"/> instances.
/// </summary>
public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    /// <summary>
    /// Creates a <see cref="AppDbContext"/> instance.
    /// </summary>
    /// <param name="args">The command line arguments.</param>
    /// <returns>A <see cref="AppDbContext"/>.</returns>
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        optionsBuilder.UseNpgsql();

        return new AppDbContext(optionsBuilder.Options);
    }
}
