// Licensed to the Rapture Project under one or more agreements.
// The Rapture Project licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Rapture.Database.Entities.Patching;

/// <summary>
/// Represents a patch channel.
/// </summary>
public class PatchChannel : IEntityTypeConfiguration<PatchChannel>
{
    /// <summary>
    /// The channel id.
    /// </summary>
    public uint Id { get; set; }

    /// <summary>
    /// The channel name.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// The repositories using this channel.
    /// </summary>
    public IEnumerable<PatchRepository> Repositories { get; set; } = [];

    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<PatchChannel> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasIndex(e => e.Name)
            .IsUnique();

        builder.HasData([
            new() { Id = 1, Name = "release" }
        ]);
    }
}
