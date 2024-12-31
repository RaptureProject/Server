// Licensed to the Rapture Project under one or more agreements.
// The Rapture Project licenses this file to you under the MIT license.

using Rapture.Web.Patching.Endpoints;
using Rapture.Web.Patching.Services;

namespace Rapture.Web.Patching;

/// <summary>
/// Patching extension methods.
/// </summary>
public static class PatchingExtensions
{
    /// <summary>
    /// Adds patching configuration to a <see cref="IHostApplicationBuilder"/>.
    /// </summary>
    /// <param name="builder">The <see cref="IHostApplicationBuilder"/> to add configuration to.</param>
    /// <returns>The <see cref="IHostApplicationBuilder"/> to continue adding configuration to.</returns>
    public static IHostApplicationBuilder ConfigurePatching(this IHostApplicationBuilder builder)
    {
        builder.Services.AddScoped<PatchService>();

        return builder;
    }

    /// <summary>
    /// Adds patching middleware to a <see cref="WebApplication"/>.
    /// </summary>
    /// <param name="app">The <see cref="WebApplication"/> to add middleware to.</param>
    /// <returns>The <see cref="WebApplication"/> to continue adding middleware to.</returns>
    public static WebApplication UsePatching(this WebApplication app)
    {
        VersionCheckEndpoint.Configure(app);

        app.UseWhen(
            context => !context.Request.Path.StartsWithSegments("/patch"),
            builder => builder.UseHttpsRedirection());

        return app;
    }
}
