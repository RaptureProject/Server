// Licensed to the Rapture Project under one or more agreements.
// The Rapture Project licenses this file to you under the MIT license.

var builder = DistributedApplication.CreateBuilder(args);

var dbPassword = builder.AddParameter("DatabasePassword", true);

var db = builder.AddPostgres("db", password: dbPassword, port: 56422)
    .WithLifetime(ContainerLifetime.Persistent)
    .WithPgAdmin(config =>
    {
        config.WithLifetime(ContainerLifetime.Persistent);
    })
    .AddDatabase("ffxiv");

builder.AddProject<Projects.Rapture_Migrator>("migrator")
    .WithReference(db)
    .WaitFor(db);

builder.AddProject<Projects.Rapture_Web>("web")
    .WithHttpHealthCheck(path: "/health", endpointName: "version")
    .WithHttpEndpoint(name: "version", port: 54996, isProxied: false)
    .WithReference(db)
    .WaitFor(db);

builder.Build().Run();
