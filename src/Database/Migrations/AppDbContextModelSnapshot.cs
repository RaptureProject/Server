﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Rapture.Database;

#nullable disable

namespace Rapture.Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "citext");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Rapture.Database.Entities.Patching.PatchChannel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("citext");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("PatchChannels");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "release"
                        });
                });

            modelBuilder.Entity("Rapture.Database.Entities.Patching.PatchPlatform", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("citext");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("PatchPlatforms");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "win32"
                        });
                });

            modelBuilder.Entity("Rapture.Database.Entities.Patching.PatchRepository", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ChannelId")
                        .HasColumnType("bigint");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasColumnType("citext");

                    b.Property<long>("PlatformId")
                        .HasColumnType("bigint");

                    b.Property<long>("TypeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ChannelId");

                    b.HasIndex("TypeId");

                    b.HasIndex("PlatformId", "ChannelId", "TypeId")
                        .IsUnique();

                    b.ToTable("PatchRepositories");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ChannelId = 1L,
                            Hash = "2d2a390f",
                            PlatformId = 1L,
                            TypeId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            ChannelId = 1L,
                            Hash = "48eca647",
                            PlatformId = 1L,
                            TypeId = 2L
                        });
                });

            modelBuilder.Entity("Rapture.Database.Entities.Patching.PatchType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("citext");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("PatchTypes");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "boot"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "game"
                        });
                });

            modelBuilder.Entity("Rapture.Database.Entities.Patching.PatchVersion", b =>
                {
                    b.Property<long>("RepositoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Version")
                        .HasColumnType("citext");

                    b.Property<DateTime>("BuildTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("FileSize")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("RepositoryId", "Version");

                    b.ToTable("PatchVersions");

                    b.HasData(
                        new
                        {
                            RepositoryId = 1L,
                            Version = "2010.07.10.0000",
                            BuildTime = new DateTime(2010, 7, 10, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 0m
                        },
                        new
                        {
                            RepositoryId = 1L,
                            Version = "2010.09.18.0000",
                            BuildTime = new DateTime(2010, 9, 18, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 5571687m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2010.07.10.0000",
                            BuildTime = new DateTime(2010, 7, 10, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 0m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2010.09.19.0000",
                            BuildTime = new DateTime(2010, 9, 19, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 444398866m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2010.09.23.0000",
                            BuildTime = new DateTime(2010, 9, 23, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 6907277m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2010.09.28.0000",
                            BuildTime = new DateTime(2010, 9, 28, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 18803280m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2010.10.07.0001",
                            BuildTime = new DateTime(2010, 10, 7, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 19226330m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2010.10.14.0000",
                            BuildTime = new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 19464329m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2010.10.22.0000",
                            BuildTime = new DateTime(2010, 10, 22, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 19778252m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2010.10.26.0000",
                            BuildTime = new DateTime(2010, 10, 26, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 19778391m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2010.11.25.0002",
                            BuildTime = new DateTime(2010, 11, 25, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 250718651m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2010.11.30.0000",
                            BuildTime = new DateTime(2010, 11, 30, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 6921623m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2010.12.06.0000",
                            BuildTime = new DateTime(2010, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 7158904m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2010.12.13.0000",
                            BuildTime = new DateTime(2010, 12, 13, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 263311481m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2010.12.21.0000",
                            BuildTime = new DateTime(2010, 12, 21, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 7521358m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2011.01.18.0000",
                            BuildTime = new DateTime(2011, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 9954265m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2011.02.01.0000",
                            BuildTime = new DateTime(2011, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 11632816m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2011.02.10.0000",
                            BuildTime = new DateTime(2011, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 11714096m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2011.03.01.0000",
                            BuildTime = new DateTime(2011, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 77464101m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2011.03.24.0000",
                            BuildTime = new DateTime(2011, 3, 24, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 108923937m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2011.03.30.0000",
                            BuildTime = new DateTime(2011, 3, 30, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 109010880m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2011.04.13.0000",
                            BuildTime = new DateTime(2011, 4, 13, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 341603850m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2011.04.21.0000",
                            BuildTime = new DateTime(2011, 4, 21, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 343579198m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2011.05.19.0000",
                            BuildTime = new DateTime(2011, 5, 19, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 344239925m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2011.06.10.0000",
                            BuildTime = new DateTime(2011, 6, 10, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 344334860m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2011.07.20.0000",
                            BuildTime = new DateTime(2011, 7, 20, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 584926805m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2011.07.26.0000",
                            BuildTime = new DateTime(2011, 7, 26, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 7649141m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2011.08.05.0000",
                            BuildTime = new DateTime(2011, 8, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 152064532m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2011.08.09.0000",
                            BuildTime = new DateTime(2011, 8, 9, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 8573687m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2011.08.16.0000",
                            BuildTime = new DateTime(2011, 8, 16, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 6118907m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2011.10.04.0000",
                            BuildTime = new DateTime(2011, 10, 4, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 677633296m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2011.10.12.0001",
                            BuildTime = new DateTime(2011, 10, 12, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 28941655m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2011.10.27.0000",
                            BuildTime = new DateTime(2011, 10, 27, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 29179764m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2011.12.14.0000",
                            BuildTime = new DateTime(2011, 12, 14, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 374617428m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2011.12.23.0000",
                            BuildTime = new DateTime(2011, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 22363713m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2012.01.18.0000",
                            BuildTime = new DateTime(2012, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 48998794m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2012.01.24.0000",
                            BuildTime = new DateTime(2012, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 49126606m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2012.01.31.0000",
                            BuildTime = new DateTime(2012, 1, 31, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 49536396m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2012.03.07.0000",
                            BuildTime = new DateTime(2012, 3, 7, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 320630782m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2012.03.09.0000",
                            BuildTime = new DateTime(2012, 3, 9, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 8312819m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2012.03.22.0000",
                            BuildTime = new DateTime(2012, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 22027738m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2012.03.29.0000",
                            BuildTime = new DateTime(2012, 3, 29, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 8322920m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2012.04.04.0000",
                            BuildTime = new DateTime(2012, 4, 4, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 8678570m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2012.04.23.0001",
                            BuildTime = new DateTime(2012, 4, 23, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 289511791m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2012.05.08.0000",
                            BuildTime = new DateTime(2012, 5, 8, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 27266546m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2012.05.15.0000",
                            BuildTime = new DateTime(2012, 5, 15, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 27416023m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2012.05.22.0000",
                            BuildTime = new DateTime(2012, 5, 22, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 27742726m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2012.06.06.0000",
                            BuildTime = new DateTime(2012, 6, 6, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 129984024m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2012.06.19.0000",
                            BuildTime = new DateTime(2012, 6, 19, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 133434217m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2012.06.26.0000",
                            BuildTime = new DateTime(2012, 6, 26, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 133581048m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2012.07.21.0000",
                            BuildTime = new DateTime(2012, 7, 21, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 253224781m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2012.08.10.0000",
                            BuildTime = new DateTime(2012, 8, 10, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 42851112m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2012.09.06.0000",
                            BuildTime = new DateTime(2012, 9, 6, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 20566711m
                        },
                        new
                        {
                            RepositoryId = 2L,
                            Version = "2012.09.19.0001",
                            BuildTime = new DateTime(2012, 9, 19, 0, 0, 0, 0, DateTimeKind.Utc),
                            FileSize = 20874726m
                        });
                });

            modelBuilder.Entity("Rapture.Database.Entities.Patching.PatchRepository", b =>
                {
                    b.HasOne("Rapture.Database.Entities.Patching.PatchChannel", "Channel")
                        .WithMany("Repositories")
                        .HasForeignKey("ChannelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rapture.Database.Entities.Patching.PatchPlatform", "Platform")
                        .WithMany("Repositories")
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rapture.Database.Entities.Patching.PatchType", "Type")
                        .WithMany("Repositories")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Channel");

                    b.Navigation("Platform");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Rapture.Database.Entities.Patching.PatchVersion", b =>
                {
                    b.HasOne("Rapture.Database.Entities.Patching.PatchRepository", "Repository")
                        .WithMany("Versions")
                        .HasForeignKey("RepositoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Repository");
                });

            modelBuilder.Entity("Rapture.Database.Entities.Patching.PatchChannel", b =>
                {
                    b.Navigation("Repositories");
                });

            modelBuilder.Entity("Rapture.Database.Entities.Patching.PatchPlatform", b =>
                {
                    b.Navigation("Repositories");
                });

            modelBuilder.Entity("Rapture.Database.Entities.Patching.PatchRepository", b =>
                {
                    b.Navigation("Versions");
                });

            modelBuilder.Entity("Rapture.Database.Entities.Patching.PatchType", b =>
                {
                    b.Navigation("Repositories");
                });
#pragma warning restore 612, 618
        }
    }
}
