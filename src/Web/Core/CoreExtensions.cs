// Licensed to the Rapture Project under one or more agreements.
// The Rapture Project licenses this file to you under the MIT license.

using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

namespace Rapture.Web.Core;

/// <summary>
/// Core extension methods.
/// </summary>
public static class CoreExtensions
{
    /// <summary>
    /// Adds core configuration to a <see cref="IHostApplicationBuilder"/>.
    /// </summary>
    /// <param name="builder">The <see cref="IHostApplicationBuilder"/> to add configuration to.</param>
    /// <returns>The <see cref="IHostApplicationBuilder"/> to continue adding configuration to.</returns>
    public static IHostApplicationBuilder ConfigureCore(this IHostApplicationBuilder builder)
    {
        builder.ConfigureTelemetry()
            .ConfigureHealthChecks()
            .ConfigureServiceDiscovery()
            .ConfigureHttpClient()
            .ConfigureOpenApi()
            .ConfigureControllers();

        return builder;
    }

    /// <summary>
    /// Adds core middleware to a <see cref="WebApplication"/>.
    /// </summary>
    /// <param name="app">The <see cref="WebApplication"/> to add middleware to.</param>
    /// <returns>The <see cref="WebApplication"/> to continue adding middleware to.</returns>
    public static WebApplication UseCore(this WebApplication app)
    {
        app.UseHealthChecks()
            .UseOpenApi()
            .UseControllers();

        return app;
    }

    private static IHostApplicationBuilder ConfigureTelemetry(this IHostApplicationBuilder builder)
    {
        builder.Logging.AddOpenTelemetry(logging =>
        {
            logging.IncludeFormattedMessage = true;
            logging.IncludeScopes = true;
        });

        builder.Services.AddOpenTelemetry()
            .WithMetrics(metrics =>
            {
                metrics.AddRuntimeInstrumentation()
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation();
            })
            .WithTracing(tracing =>
            {
                tracing.AddSource(builder.Environment.ApplicationName)
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddEntityFrameworkCoreInstrumentation(options =>
                    {
                        options.SetDbStatementForText = true;
                        options.SetDbStatementForStoredProcedure = true;
                    });
            });

        if (!string.IsNullOrWhiteSpace(builder.Configuration["OTEL_EXPORTER_OTLP_ENDPOINT"]))
        {
            builder.Services.AddOpenTelemetry()
                .UseOtlpExporter();
        }

        return builder;
    }

    private static IHostApplicationBuilder ConfigureHealthChecks(this IHostApplicationBuilder builder)
    {
        builder.Services.AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy(), ["live"]);

        return builder;
    }

    private static WebApplication UseHealthChecks(this WebApplication app)
    {
        app.MapHealthChecks("/health");

        app.MapHealthChecks("/alive", new HealthCheckOptions
        {
            Predicate = r => r.Tags.Contains("live")
        });

        return app;
    }

    private static IHostApplicationBuilder ConfigureServiceDiscovery(this IHostApplicationBuilder builder)
    {
        builder.Services.AddServiceDiscovery();

        return builder;
    }

    private static IHostApplicationBuilder ConfigureHttpClient(this IHostApplicationBuilder builder)
    {
        builder.Services.ConfigureHttpClientDefaults(http =>
        {
            http.AddStandardResilienceHandler();
            http.AddServiceDiscovery();
        });

        return builder;
    }

    private static IHostApplicationBuilder ConfigureOpenApi(this IHostApplicationBuilder builder)
    {
        builder.Services.AddOpenApi(options =>
        {
            options.AddDocumentTransformer((document, context, candellationToken) =>
            {
                document.Info.Title = "Rapture";
                document.Info.Description = "A Final Fantasy XIV 1.23b server emulator.";
                document.Info.TermsOfService = new("https://github.com/RaptureProject/Server/blob/main/CODE_OF_CONDUCT.md");

                document.Info.Contact = new()
                {
                    Name = "Rapture Project",
                    Email = "community@raptureproject.com",
                    Url = new("https://github.com/RaptureProject/Server")
                };

                document.Info.License = new()
                {
                    Name = "MIT License",
                    Url = new("https://github.com/RaptureProject/Server/blob/main/LICENSE.txt")
                };

                return Task.CompletedTask;
            });
        });

        return builder;
    }

    private static WebApplication UseOpenApi(this WebApplication app)
    {
        app.MapOpenApi();

        return app;
    }

    private static IHostApplicationBuilder ConfigureControllers(this IHostApplicationBuilder builder)
    {
        builder.Services.AddControllers();

        return builder;
    }

    private static WebApplication UseControllers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }
}
