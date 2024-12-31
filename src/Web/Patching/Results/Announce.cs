// Licensed to the Rapture Project under one or more agreements.
// The Rapture Project licenses this file to you under the MIT license.

using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.Extensions.ServiceDiscovery;
using MonoTorrent.BEncoding;
using System.Net;
using System.Reflection;

namespace Rapture.Web.Patching.Results;

/// <summary>
/// An <see cref="IResult"/> that on execution will write announcement data to the response
/// with Ok (200) status code.
/// </summary>
public class Announce : IResult, IEndpointMetadataProvider, IStatusCodeHttpResult, IValueHttpResult, IValueHttpResult<string>
{
    /// <summary>
    /// Gets the HTTP status code: <see cref="StatusCodes.Status200OK"/>
    /// </summary>
    public int? StatusCode => 200;

    /// <summary>
    /// Gets the service name.
    /// </summary>
    public string? Value { get; }

    object? IValueHttpResult.Value => Value;

    /// <summary>
    /// Creates a <see cref="Announce"/> result type.
    /// </summary>
    /// <param name="serviceName">The service name that contains the IPs of peers.</param>
    public Announce(string serviceName)
    {
        Value = serviceName;
    }

    /// <inheritdoc/>
    public async Task ExecuteAsync(HttpContext httpContext)
    {
        if (Value == null)
        {
            throw new InvalidOperationException("Service name cannot be null!");
        }

        httpContext.Response.StatusCode = (int)StatusCode!;
        httpContext.Response.ContentType = "text/plain";

        httpContext.Response.Headers["Connection"] = "close";

        var serviceResolver = httpContext.RequestServices.GetRequiredService<ServiceEndpointResolver>();

        var endpointSource = await serviceResolver.GetEndpointsAsync(Value, new());
        var endpoints = endpointSource.Endpoints.Select(e => new Uri(e.EndPoint.ToString()!));

        var peers = new List<byte>();

        foreach (var endpoint in endpoints)
        {
            var address = IPAddress.Parse(endpoint.Host).GetAddressBytes();
            var port = BitConverter.GetBytes(endpoint.Port);
            var entry = new byte[address.Length + port.Length];

            Array.Copy(address, entry, address.Length);
            Array.Copy(port, 0, entry, address.Length, port.Length);

            peers.AddRange(entry);
        }

        var response = new BEncodedDictionary
        {
            { "tracker id", new BEncodedString("SQ0001-DcPDIHCph") },
            { "interval", new BEncodedNumber(2700) },
            { "min interval", new BEncodedNumber(600) },
            { "complete", new BEncodedNumber(1) },
            { "incomplete", new BEncodedNumber(0) },
            { "downloaded", new BEncodedNumber(0) },
            { "peers", (BEncodedString)peers.ToArray() }
        };

        await httpContext.Response.Body.WriteAsync(response.Encode());
    }

    /// <inheritdoc/>
    public static void PopulateMetadata(MethodInfo method, EndpointBuilder builder)
    {
        builder.Metadata.Add(new ProducesResponseTypeMetadata(StatusCodes.Status200OK, typeof(void)));
    }
}
