// Licensed to the Rapture Project under one or more agreements.
// The Rapture Project licenses this file to you under the MIT license.

var builder = DistributedApplication.CreateBuilder(args);

var dbPassword = builder.AddParameter("DatabasePassword", true);
var patchHost = builder.AddParameter("PatchServer", true);

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
    .WithEnvironment("services__patch__default__0", patchHost)
    .WithHttpEndpoint(name: "http", port: 8080, isProxied: false)
    .WithHttpsEndpoint(name: "https", port: 8443, isProxied: false)
    .WithReference(db)
    .WaitFor(db);

builder.Build().Run();
