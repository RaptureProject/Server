// Licensed to the Rapture Project under one or more agreements.
// The Rapture Project licenses this file to you under the MIT license.

using Microsoft.AspNetCore.Http.HttpResults;
using Rapture.Web.Patching.Results;
using Rapture.Web.Patching.Services;
using System.ComponentModel;

namespace Rapture.Web.Patching.Endpoints;

/// <summary>
/// Handles version checking.
/// </summary>
public class VersionCheckEndpoint
{
    /// <summary>
    /// Configures the endpoint.
    /// </summary>
    /// <param name="builder">The <see cref="IEndpointRouteBuilder"/>.</param>
    public static void Configure(IEndpointRouteBuilder builder)
    {
        builder.MapGet("patch/vercheck/ffxiv/{platform}/{channel}/{type}/{version}", Handle)
            .WithDescription("Uses a clients platform, channel, type, and version info to determine if it is up to date.")
            .WithSummary("Version Check")
            .WithTags("Patching");
    }

    private static async Task<Results<UpdateInfo, UpToDate, NotFound>> Handle(
        [Description("The clients platform name.")] string platform,
        [Description("The clients channel name.")] string channel,
        [Description("The type of client being checked.")] string type,
        [Description("The clients current patch version.")] string version,
        PatchService patchService)
    {
        var currentPatch = await patchService.GetPatch(platform, channel, type, version);

        if (currentPatch == null)
        {
            return TypedResults.NotFound();
        }

        var latestVersion = await patchService.GetLatestVersion(platform, channel, type);

        if (version == latestVersion.Version)
        {
            return PatchResults.UpToDate(latestVersion);
        }

        var updateVersions = await patchService.GetUpdateVersions(platform, channel, type, currentPatch);

        return PatchResults.UpdateInfo(updateVersions);
    }
}
