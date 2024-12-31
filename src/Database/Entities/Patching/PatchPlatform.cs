// Licensed to the Rapture Project under one or more agreements.
// The Rapture Project licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Rapture.Database.Entities.Patching;

/// <summary>
/// Represents a patch platform.
/// </summary>
public class PatchPlatform : IEntityTypeConfiguration<PatchPlatform>
{
    /// <summary>
    /// The platform id.
    /// </summary>
    public uint Id { get; set; }

    /// <summary>
    /// The platform name.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// The repositories using this platform.
    /// </summary>
    public IEnumerable<PatchRepository> Repositories { get; set; } = [];

    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<PatchPlatform> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasIndex(e => e.Name)
            .IsUnique();

        builder.HasData([
            new() { Id = 1, Name = "win32" }
        ]);
    }
}
