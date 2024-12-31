// Licensed to the Rapture Project under one or more agreements.
// The Rapture Project licenses this file to you under the MIT license.

using Rapture.Web.Core;
using Rapture.Web.Data;
using Rapture.Web.Patching;
using Rapture.Web.Shell;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureCore()
    .ConfigureData()
    .ConfigurePatching();

var app = builder.Build();

app.UseCore()
    .UseShell()
    .UsePatching();

app.Run();
