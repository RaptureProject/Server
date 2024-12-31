// Licensed to the Rapture Project under one or more agreements.
// The Rapture Project licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore;
using Rapture.Database;
using Rapture.Web.Patching.Models;

namespace Rapture.Web.Patching.Services;

/// <summary>
/// Service that handles patching duties.
/// </summary>
public class PatchService
{
    private readonly AppDbContext _context;

    /// <summary>
    /// Creates a <see cref="PatchService"/> instance.
    /// </summary>
    /// <param name="context">The <see cref="AppDbContext"/>.</param>
    public PatchService(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets a patch.
    /// </summary>
    /// <param name="platform">The patch platform.</param>
    /// <param name="channel">The patch channel.</param>
    /// <param name="type">The patch type.</param>
    /// <param name="version">The patch version.</param>
    /// <returns>The patch info if the patch exists, otherwise null.</returns>
    public async Task<PatchInfo?> GetPatch(string platform, string channel, string type, string version)
    {
        return await _context.PatchVersions
            .Where(v => v.Repository!.Platform!.Name == platform)
            .Where(v => v.Repository!.Channel!.Name == channel)
            .Where(v => v.Repository!.Type!.Name == type)
            .Where(v => v.Version == version)
            .Select(v => new PatchInfo()
            {
                Platform = v.Repository!.Platform!.Name,
                Channel = v.Repository!.Channel!.Name,
                Type = v.Repository!.Type!.Name,
                Version = v.Version,
                BuildTime = v.BuildTime,
                FileSize = v.FileSize,
                RepositoryHash = v.Repository!.Hash
            })
            .FirstOrDefaultAsync();
    }

    /// <summary>
    /// Gets the latest version.
    /// </summary>
    /// <param name="platform">The patch platform.</param>
    /// <param name="channel">The patch channel.</param>
    /// <param name="type">The patch type.</param>
    /// <returns>True if the patch exists, otherwise false.</returns>
    public async Task<PatchInfo> GetLatestVersion(string platform, string channel, string type)
    {
        return await _context.PatchVersions
            .Where(v => v.Repository!.Platform!.Name == platform)
            .Where(v => v.Repository!.Channel!.Name == channel)
            .Where(v => v.Repository!.Type!.Name == type)
            .OrderBy(v => v.BuildTime)
            .Select(v => new PatchInfo()
            {
                Platform = v.Repository!.Platform!.Name,
                Channel = v.Repository!.Channel!.Name,
                Type = v.Repository!.Type!.Name,
                Version = v.Version,
                BuildTime = v.BuildTime,
                FileSize = v.FileSize,
                RepositoryHash = v.Repository!.Hash
            })
            .LastAsync();
    }

    /// <summary>
    /// Gets the versions needed to get up to date.
    /// </summary>
    /// <param name="platform">The patch platform.</param>
    /// <param name="channel">The patch channel.</param>
    /// <param name="type">The patch type.</param>
    /// <param name="currentVersion">The current patch version.</param>
    /// <returns>True if the patch exists, otherwise false.</returns>
    public async Task<IEnumerable<PatchInfo>> GetUpdateVersions(string platform, string channel, string type, PatchInfo currentVersion)
    {
        return await _context.PatchVersions
            .Where(v => v.Repository!.Platform!.Name == platform)
            .Where(v => v.Repository!.Channel!.Name == channel)
            .Where(v => v.Repository!.Type!.Name == type)
            .Where(v => v.BuildTime > currentVersion.BuildTime)
            .OrderBy(v => v.BuildTime)
            .Select(v => new PatchInfo()
            {
                Platform = v.Repository!.Platform!.Name,
                Channel = v.Repository!.Channel!.Name,
                Type = v.Repository!.Type!.Name,
                Version = v.Version,
                BuildTime = v.BuildTime,
                FileSize = v.FileSize,
                RepositoryHash = v.Repository!.Hash
            })
            .ToListAsync();
    }
}
