// Licensed to the Rapture Project under one or more agreements.
// The Rapture Project licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Rapture.Database.Migrations;

/// <inheritdoc />
public partial class Patching : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterDatabase()
            .Annotation("Npgsql:PostgresExtension:citext", ",,");

        migrationBuilder.CreateTable(
            name: "PatchChannels",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Name = table.Column<string>(type: "citext", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PatchChannels", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "PatchPlatforms",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Name = table.Column<string>(type: "citext", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PatchPlatforms", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "PatchTypes",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Name = table.Column<string>(type: "citext", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PatchTypes", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "PatchRepositories",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                PlatformId = table.Column<long>(type: "bigint", nullable: false),
                ChannelId = table.Column<long>(type: "bigint", nullable: false),
                TypeId = table.Column<long>(type: "bigint", nullable: false),
                Hash = table.Column<string>(type: "citext", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PatchRepositories", x => x.Id);
                table.ForeignKey(
                    name: "FK_PatchRepositories_PatchChannels_ChannelId",
                    column: x => x.ChannelId,
                    principalTable: "PatchChannels",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_PatchRepositories_PatchPlatforms_PlatformId",
                    column: x => x.PlatformId,
                    principalTable: "PatchPlatforms",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_PatchRepositories_PatchTypes_TypeId",
                    column: x => x.TypeId,
                    principalTable: "PatchTypes",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "PatchVersions",
            columns: table => new
            {
                RepositoryId = table.Column<long>(type: "bigint", nullable: false),
                Version = table.Column<string>(type: "citext", nullable: false),
                BuildTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                FileSize = table.Column<decimal>(type: "numeric(20,0)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PatchVersions", x => new { x.RepositoryId, x.Version });
                table.ForeignKey(
                    name: "FK_PatchVersions_PatchRepositories_RepositoryId",
                    column: x => x.RepositoryId,
                    principalTable: "PatchRepositories",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.InsertData(
            table: "PatchChannels",
            columns: new[] { "Id", "Name" },
            values: new object[] { 1L, "release" });

        migrationBuilder.InsertData(
            table: "PatchPlatforms",
            columns: new[] { "Id", "Name" },
            values: new object[] { 1L, "win32" });

        migrationBuilder.InsertData(
            table: "PatchTypes",
            columns: new[] { "Id", "Name" },
            values: new object[,]
            {
                { 1L, "boot" },
                { 2L, "game" }
            });

        migrationBuilder.InsertData(
            table: "PatchRepositories",
            columns: new[] { "Id", "ChannelId", "Hash", "PlatformId", "TypeId" },
            values: new object[,]
            {
                { 1L, 1L, "2d2a390f", 1L, 1L },
                { 2L, 1L, "48eca647", 1L, 2L }
            });

        migrationBuilder.InsertData(
            table: "PatchVersions",
            columns: new[] { "RepositoryId", "Version", "BuildTime", "FileSize" },
            values: new object[,]
            {
                { 1L, "2010.07.10.0000", new DateTime(2010, 7, 10, 0, 0, 0, 0, DateTimeKind.Utc), 0m },
                { 1L, "2010.09.18.0000", new DateTime(2010, 9, 18, 0, 0, 0, 0, DateTimeKind.Utc), 5571687m },
                { 2L, "2010.07.10.0000", new DateTime(2010, 7, 10, 0, 0, 0, 0, DateTimeKind.Utc), 0m },
                { 2L, "2010.09.19.0000", new DateTime(2010, 9, 19, 0, 0, 0, 0, DateTimeKind.Utc), 444398866m },
                { 2L, "2010.09.23.0000", new DateTime(2010, 9, 23, 0, 0, 0, 0, DateTimeKind.Utc), 6907277m },
                { 2L, "2010.09.28.0000", new DateTime(2010, 9, 28, 0, 0, 0, 0, DateTimeKind.Utc), 18803280m },
                { 2L, "2010.10.07.0001", new DateTime(2010, 10, 7, 0, 0, 0, 0, DateTimeKind.Utc), 19226330m },
                { 2L, "2010.10.14.0000", new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), 19464329m },
                { 2L, "2010.10.22.0000", new DateTime(2010, 10, 22, 0, 0, 0, 0, DateTimeKind.Utc), 19778252m },
                { 2L, "2010.10.26.0000", new DateTime(2010, 10, 26, 0, 0, 0, 0, DateTimeKind.Utc), 19778391m },
                { 2L, "2010.11.25.0002", new DateTime(2010, 11, 25, 0, 0, 0, 0, DateTimeKind.Utc), 250718651m },
                { 2L, "2010.11.30.0000", new DateTime(2010, 11, 30, 0, 0, 0, 0, DateTimeKind.Utc), 6921623m },
                { 2L, "2010.12.06.0000", new DateTime(2010, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc), 7158904m },
                { 2L, "2010.12.13.0000", new DateTime(2010, 12, 13, 0, 0, 0, 0, DateTimeKind.Utc), 263311481m },
                { 2L, "2010.12.21.0000", new DateTime(2010, 12, 21, 0, 0, 0, 0, DateTimeKind.Utc), 7521358m },
                { 2L, "2011.01.18.0000", new DateTime(2011, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), 9954265m },
                { 2L, "2011.02.01.0000", new DateTime(2011, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), 11632816m },
                { 2L, "2011.02.10.0000", new DateTime(2011, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), 11714096m },
                { 2L, "2011.03.01.0000", new DateTime(2011, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), 77464101m },
                { 2L, "2011.03.24.0000", new DateTime(2011, 3, 24, 0, 0, 0, 0, DateTimeKind.Utc), 108923937m },
                { 2L, "2011.03.30.0000", new DateTime(2011, 3, 30, 0, 0, 0, 0, DateTimeKind.Utc), 109010880m },
                { 2L, "2011.04.13.0000", new DateTime(2011, 4, 13, 0, 0, 0, 0, DateTimeKind.Utc), 341603850m },
                { 2L, "2011.04.21.0000", new DateTime(2011, 4, 21, 0, 0, 0, 0, DateTimeKind.Utc), 343579198m },
                { 2L, "2011.05.19.0000", new DateTime(2011, 5, 19, 0, 0, 0, 0, DateTimeKind.Utc), 344239925m },
                { 2L, "2011.06.10.0000", new DateTime(2011, 6, 10, 0, 0, 0, 0, DateTimeKind.Utc), 344334860m },
                { 2L, "2011.07.20.0000", new DateTime(2011, 7, 20, 0, 0, 0, 0, DateTimeKind.Utc), 584926805m },
                { 2L, "2011.07.26.0000", new DateTime(2011, 7, 26, 0, 0, 0, 0, DateTimeKind.Utc), 7649141m },
                { 2L, "2011.08.05.0000", new DateTime(2011, 8, 5, 0, 0, 0, 0, DateTimeKind.Utc), 152064532m },
                { 2L, "2011.08.09.0000", new DateTime(2011, 8, 9, 0, 0, 0, 0, DateTimeKind.Utc), 8573687m },
                { 2L, "2011.08.16.0000", new DateTime(2011, 8, 16, 0, 0, 0, 0, DateTimeKind.Utc), 6118907m },
                { 2L, "2011.10.04.0000", new DateTime(2011, 10, 4, 0, 0, 0, 0, DateTimeKind.Utc), 677633296m },
                { 2L, "2011.10.12.0001", new DateTime(2011, 10, 12, 0, 0, 0, 0, DateTimeKind.Utc), 28941655m },
                { 2L, "2011.10.27.0000", new DateTime(2011, 10, 27, 0, 0, 0, 0, DateTimeKind.Utc), 29179764m },
                { 2L, "2011.12.14.0000", new DateTime(2011, 12, 14, 0, 0, 0, 0, DateTimeKind.Utc), 374617428m },
                { 2L, "2011.12.23.0000", new DateTime(2011, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), 22363713m },
                { 2L, "2012.01.18.0000", new DateTime(2012, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), 48998794m },
                { 2L, "2012.01.24.0000", new DateTime(2012, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), 49126606m },
                { 2L, "2012.01.31.0000", new DateTime(2012, 1, 31, 0, 0, 0, 0, DateTimeKind.Utc), 49536396m },
                { 2L, "2012.03.07.0000", new DateTime(2012, 3, 7, 0, 0, 0, 0, DateTimeKind.Utc), 320630782m },
                { 2L, "2012.03.09.0000", new DateTime(2012, 3, 9, 0, 0, 0, 0, DateTimeKind.Utc), 8312819m },
                { 2L, "2012.03.22.0000", new DateTime(2012, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc), 22027738m },
                { 2L, "2012.03.29.0000", new DateTime(2012, 3, 29, 0, 0, 0, 0, DateTimeKind.Utc), 8322920m },
                { 2L, "2012.04.04.0000", new DateTime(2012, 4, 4, 0, 0, 0, 0, DateTimeKind.Utc), 8678570m },
                { 2L, "2012.04.23.0001", new DateTime(2012, 4, 23, 0, 0, 0, 0, DateTimeKind.Utc), 289511791m },
                { 2L, "2012.05.08.0000", new DateTime(2012, 5, 8, 0, 0, 0, 0, DateTimeKind.Utc), 27266546m },
                { 2L, "2012.05.15.0000", new DateTime(2012, 5, 15, 0, 0, 0, 0, DateTimeKind.Utc), 27416023m },
                { 2L, "2012.05.22.0000", new DateTime(2012, 5, 22, 0, 0, 0, 0, DateTimeKind.Utc), 27742726m },
                { 2L, "2012.06.06.0000", new DateTime(2012, 6, 6, 0, 0, 0, 0, DateTimeKind.Utc), 129984024m },
                { 2L, "2012.06.19.0000", new DateTime(2012, 6, 19, 0, 0, 0, 0, DateTimeKind.Utc), 133434217m },
                { 2L, "2012.06.26.0000", new DateTime(2012, 6, 26, 0, 0, 0, 0, DateTimeKind.Utc), 133581048m },
                { 2L, "2012.07.21.0000", new DateTime(2012, 7, 21, 0, 0, 0, 0, DateTimeKind.Utc), 253224781m },
                { 2L, "2012.08.10.0000", new DateTime(2012, 8, 10, 0, 0, 0, 0, DateTimeKind.Utc), 42851112m },
                { 2L, "2012.09.06.0000", new DateTime(2012, 9, 6, 0, 0, 0, 0, DateTimeKind.Utc), 20566711m },
                { 2L, "2012.09.19.0001", new DateTime(2012, 9, 19, 0, 0, 0, 0, DateTimeKind.Utc), 20874726m }
            });

        migrationBuilder.CreateIndex(
            name: "IX_PatchChannels_Name",
            table: "PatchChannels",
            column: "Name",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_PatchPlatforms_Name",
            table: "PatchPlatforms",
            column: "Name",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_PatchRepositories_ChannelId",
            table: "PatchRepositories",
            column: "ChannelId");

        migrationBuilder.CreateIndex(
            name: "IX_PatchRepositories_PlatformId_ChannelId_TypeId",
            table: "PatchRepositories",
            columns: new[] { "PlatformId", "ChannelId", "TypeId" },
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_PatchRepositories_TypeId",
            table: "PatchRepositories",
            column: "TypeId");

        migrationBuilder.CreateIndex(
            name: "IX_PatchTypes_Name",
            table: "PatchTypes",
            column: "Name",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "PatchVersions");

        migrationBuilder.DropTable(
            name: "PatchRepositories");

        migrationBuilder.DropTable(
            name: "PatchChannels");

        migrationBuilder.DropTable(
            name: "PatchPlatforms");

        migrationBuilder.DropTable(
            name: "PatchTypes");
    }
}
