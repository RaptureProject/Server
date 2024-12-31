// Licensed to the Rapture Project under one or more agreements.
// The Rapture Project licenses this file to you under the MIT license.

namespace Rapture.Web.Patching.Models;

/// <summary>
/// Represents information for a single patch.
/// </summary>
public class PatchInfo
{
    /// <summary>
    /// The platform name.
    /// </summary>
    public required string Platform { get; set; }

    /// <summary>
    /// The channel name.
    /// </summary>
    public required string Channel { get; set; }

    /// <summary>
    /// The patch type.
    /// </summary>
    public required string Type { get; set; }

    /// <summary>
    /// The patch version.
    /// </summary>
    public required string Version { get; set; }

    /// <summary>
    /// The patch build time.
    /// </summary>
    public required DateTime BuildTime { get; set; }

    /// <summary>
    /// The patch file size.
    /// </summary>
    public required ulong FileSize { get; set; }

    /// <summary>
    /// The repository hash.
    /// </summary>
    public required string RepositoryHash { get; set; }
}
