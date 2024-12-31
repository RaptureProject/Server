// Licensed to the Rapture Project under one or more agreements.
// The Rapture Project licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Rapture.Database.Entities.Patching;

/// <summary>
/// Represents a patch repository.
/// </summary>
public class PatchRepository : IEntityTypeConfiguration<PatchRepository>
{
    /// <summary>
    /// The repository id.
    /// </summary>
    public uint Id { get; set; }

    /// <summary>
    /// The repository platform id.
    /// </summary>
    public uint PlatformId { get; set; }

    /// <summary>
    /// The repository platform.
    /// </summary>
    public PatchPlatform? Platform { get; set; }

    /// <summary>
    /// The repository channel id.
    /// </summary>
    public uint ChannelId { get; set; }

    /// <summary>
    /// The repository channel.
    /// </summary>
    public PatchChannel? Channel { get; set; }

    /// <summary>
    /// The repository type id.
    /// </summary>
    public uint TypeId { get; set; }

    /// <summary>
    /// The repository type.
    /// </summary>
    public PatchType? Type { get; set; }

    /// <summary>
    /// The repository hash.
    /// </summary>
    public required string Hash { get; set; }

    /// <summary>
    /// The versions in this repository,
    /// </summary>
    public IEnumerable<PatchVersion> Versions { get; set; } = [];

    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<PatchRepository> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasIndex(e => new { e.PlatformId, e.ChannelId, e.TypeId })
            .IsUnique();

        builder.HasOne(e => e.Platform)
            .WithMany(e => e.Repositories)
            .HasPrincipalKey(e => e.Id)
            .HasForeignKey(e => e.PlatformId);

        builder.HasOne(e => e.Channel)
            .WithMany(e => e.Repositories)
            .HasPrincipalKey(e => e.Id)
            .HasForeignKey(e => e.ChannelId);

        builder.HasOne(e => e.Type)
            .WithMany(e => e.Repositories)
            .HasPrincipalKey(e => e.Id)
            .HasForeignKey(e => e.TypeId);

        builder.HasMany(e => e.Versions)
            .WithOne(e => e.Repository)
            .HasPrincipalKey(e => e.Id)
            .HasForeignKey(e => e.RepositoryId);

        builder.HasData([
            new() { Id = 1, PlatformId = 1, ChannelId = 1, TypeId = 1, Hash = "2d2a390f" },
            new() { Id = 2, PlatformId = 1, ChannelId = 1, TypeId = 2, Hash = "48eca647" }
        ]);
    }
}
