// Licensed to the Rapture Project under one or more agreements.
// The Rapture Project licenses this file to you under the MIT license.

using Microsoft.AspNetCore.Http.Metadata;
using Rapture.Web.Patching.Models;
using System.Reflection;

namespace Rapture.Web.Patching.Results;

/// <summary>
/// An <see cref="IResult"/> that on execution will write up to date patch info to the response
/// with No Content (204) status code.
/// </summary>
public class UpToDate : IResult, IEndpointMetadataProvider, IStatusCodeHttpResult, IValueHttpResult, IValueHttpResult<PatchInfo>
{
    /// <summary>
    /// Gets the HTTP status code: <see cref="StatusCodes.Status204NoContent"/>
    /// </summary>
    public int? StatusCode => 204;

    /// <summary>
    /// Gets the latest patch info.
    /// </summary>
    public PatchInfo? Value { get; }

    object? IValueHttpResult.Value => Value;

    /// <summary>
    /// Creates a <see cref="UpToDate"/> result type.
    /// </summary>
    /// <param name="info">The <see cref="PatchInfo"/> used to write the response.</param>
    public UpToDate(PatchInfo info)
    {
        Value = info;
    }

    /// <inheritdoc/>
    public Task ExecuteAsync(HttpContext httpContext)
    {
        if (Value == null)
        {
            throw new InvalidOperationException("Patch data cannot be null!");
        }

        httpContext.Response.StatusCode = (int)StatusCode!;

        httpContext.Response.Headers["Content-Location"] = $"ffxiv/{Value.RepositoryHash}/vercheck.dat";
        httpContext.Response.Headers["X-Repository"] = $"ffxiv/{Value.Platform}/{Value.Channel}/{Value.Type}";
        httpContext.Response.Headers["X-Patch-Module"] = "ZiPatch";
        httpContext.Response.Headers["X-Protocol"] = "torrent";
        httpContext.Response.Headers["X-Info-Url"] = "http://example.com";
        httpContext.Response.Headers["X-Latest-Version"] = Value.Version;

        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public static void PopulateMetadata(MethodInfo method, EndpointBuilder builder)
    {
        builder.Metadata.Add(new ProducesResponseTypeMetadata(StatusCodes.Status204NoContent, typeof(void)));
    }
}
