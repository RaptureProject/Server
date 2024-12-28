// Licensed to the Rapture Project under one or more agreements.
// The Rapture Project licenses this file to you under the MIT license.

using Rapture.Web.Core;
using Rapture.Web.Shell;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureCore();

var app = builder.Build();

app.UseCore()
    .UseShell();

app.Run();
