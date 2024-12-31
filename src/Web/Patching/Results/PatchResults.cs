// Licensed to the Rapture Project under one or more agreements.
// The Rapture Project licenses this file to you under the MIT license.

using Rapture.Web.Patching.Models;

namespace Rapture.Web.Patching.Results;

/// <summary>
/// A typed factory for <see cref="IResult"/> types in <see cref="Results"/>.
/// </summary>
public static class PatchResults
{
    /// <summary>
    /// Produces a <see cref="StatusCodes.Status204NoContent"/> response.
    /// </summary>
    /// <param name="info">The value to be included in the HTTP response.</param>
    /// <returns>The created <see cref="UpToDate(PatchInfo)"/> for the response.</returns>
    public static UpToDate UpToDate(PatchInfo info)
    {
        return new(info);
    }

    /// <summary>
    /// Produces a <see cref="StatusCodes.Status200OK"/> response.
    /// </summary>
    /// <param name="updateInfo">The value to be included in the HTTP response.</param>
    /// <returns>The created <see cref="UpdateInfo(IEnumerable{PatchInfo})"/> for the response.</returns>
    public static UpdateInfo UpdateInfo(IEnumerable<PatchInfo> updateInfo)
    {
        return new(updateInfo);
    }
}
