// Licensed to the Rapture Project under one or more agreements.
// The Rapture Project licenses this file to you under the MIT license.

using Rapture.Migrator.Core;
using Rapture.Migrator.Data;

var builder = Host.CreateApplicationBuilder(args);

builder.ConfigureCore()
    .ConfigureData();

builder.Build().Run();
