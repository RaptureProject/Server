// Licensed to the Rapture Project under one or more agreements.
// The Rapture Project licenses this file to you under the MIT license.

using Rapture.Web.Patching.Results;

namespace Rapture.Web.Patching.Endpoints;

/// <summary>
/// Handles announcing peers.
/// </summary>
public class AnnounceEndpoint
{
    /// <summary>
    /// Configures the endpoint.
    /// </summary>
    /// <param name="builder">The <see cref="IEndpointRouteBuilder"/>.</param>
    public static void Configure(IEndpointRouteBuilder builder)
    {
        builder.MapGet("announce", Handle)
            .WithDescription("Provides information on servers hosting patch data.")
            .WithSummary("Announce")
            .WithTags("Patching");
    }

    private static Announce Handle()
    {
        return PatchResults.Announce("patch");
    }
}
