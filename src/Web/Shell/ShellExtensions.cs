// Licensed to the Rapture Project under one or more agreements.
// The Rapture Project licenses this file to you under the MIT license.

using Scalar.AspNetCore;

namespace Rapture.Web.Shell;

/// <summary>
/// Shell extension methods.
/// </summary>
public static class ShellExtensions
{
    /// <summary>
    /// Adds shell middleware to a <see cref="WebApplication"/>.
    /// </summary>
    /// <param name="app">The <see cref="WebApplication"/> to add middleware to.</param>
    /// <returns>The <see cref="WebApplication"/> to continue adding middleware to.</returns>
    public static WebApplication UseShell(this WebApplication app)
    {
        app.MapScalarApiReference(options =>
        {
            options.WithTitle("Rapture");
            options.HideClientButton = true;
        });

        return app;
    }
}
