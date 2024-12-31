// Licensed to the Rapture Project under one or more agreements.
// The Rapture Project licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Rapture.Database.Entities.Patching;

/// <summary>
/// Represents a patch type.
/// </summary>
public class PatchType : IEntityTypeConfiguration<PatchType>
{
    /// <summary>
    /// The type id.
    /// </summary>
    public uint Id { get; set; }

    /// <summary>
    /// The type name.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// The repositories using this type.
    /// </summary>
    public IEnumerable<PatchRepository> Repositories { get; set; } = [];

    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<PatchType> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasIndex(e => e.Name)
            .IsUnique();

        builder.HasData([
            new() { Id = 1, Name = "boot" },
            new() { Id = 2, Name = "game" }
        ]);
    }
}
