// Licensed to the Rapture Project under one or more agreements.
// The Rapture Project licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Rapture.Database.Entities.Patching;

/// <summary>
/// Represents a patch version.
/// </summary>
public class PatchVersion : IEntityTypeConfiguration<PatchVersion>
{
    /// <summary>
    /// The repository id.
    /// </summary>
    public uint RepositoryId { get; set; }

    /// <summary>
    /// The repository.
    /// </summary>
    public PatchRepository? Repository { get; set; }

    /// <summary>
    /// The patch version.
    /// </summary>
    public required string Version { get; set; }

    /// <summary>
    /// The patch build time.
    /// </summary>
    public DateTime BuildTime { get; set; }

    /// <summary>
    /// The patch file size.
    /// </summary>
    public ulong FileSize { get; set; }

    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<PatchVersion> builder)
    {
        builder.HasKey(e => new { e.RepositoryId, e.Version });

        var test = new DateTime(10, 10, 10, 10, 10, 10, DateTimeKind.Utc);

        builder.HasData([
            new() { RepositoryId = 1, Version = "2010.07.10.0000", BuildTime = new(2010, 07, 10, 0, 0, 0, DateTimeKind.Utc), FileSize = 0 },
            new() { RepositoryId = 1, Version = "2010.09.18.0000", BuildTime = new(2010, 09, 18, 0, 0, 0, DateTimeKind.Utc), FileSize = 5571687 },
            new() { RepositoryId = 2, Version = "2010.07.10.0000", BuildTime = new(2010, 07, 10, 0, 0, 0, DateTimeKind.Utc), FileSize = 0 },
            new() { RepositoryId = 2, Version = "2010.09.19.0000", BuildTime = new(2010, 09, 19, 0, 0, 0, DateTimeKind.Utc), FileSize = 444398866 },
            new() { RepositoryId = 2, Version = "2010.09.23.0000", BuildTime = new(2010, 09, 23, 0, 0, 0, DateTimeKind.Utc), FileSize = 6907277 },
            new() { RepositoryId = 2, Version = "2010.09.28.0000", BuildTime = new(2010, 09, 28, 0, 0, 0, DateTimeKind.Utc), FileSize = 18803280 },
            new() { RepositoryId = 2, Version = "2010.10.07.0001", BuildTime = new(2010, 10, 07, 0, 0, 0, DateTimeKind.Utc), FileSize = 19226330 },
            new() { RepositoryId = 2, Version = "2010.10.14.0000", BuildTime = new(2010, 10, 14, 0, 0, 0, DateTimeKind.Utc), FileSize = 19464329 },
            new() { RepositoryId = 2, Version = "2010.10.22.0000", BuildTime = new(2010, 10, 22, 0, 0, 0, DateTimeKind.Utc), FileSize = 19778252 },
            new() { RepositoryId = 2, Version = "2010.10.26.0000", BuildTime = new(2010, 10, 26, 0, 0, 0, DateTimeKind.Utc), FileSize = 19778391 },
            new() { RepositoryId = 2, Version = "2010.11.25.0002", BuildTime = new(2010, 11, 25, 0, 0, 0, DateTimeKind.Utc), FileSize = 250718651 },
            new() { RepositoryId = 2, Version = "2010.11.30.0000", BuildTime = new(2010, 11, 30, 0, 0, 0, DateTimeKind.Utc), FileSize = 6921623 },
            new() { RepositoryId = 2, Version = "2010.12.06.0000", BuildTime = new(2010, 12, 06, 0, 0, 0, DateTimeKind.Utc), FileSize = 7158904 },
            new() { RepositoryId = 2, Version = "2010.12.13.0000", BuildTime = new(2010, 12, 13, 0, 0, 0, DateTimeKind.Utc), FileSize = 263311481 },
            new() { RepositoryId = 2, Version = "2010.12.21.0000", BuildTime = new(2010, 12, 21, 0, 0, 0, DateTimeKind.Utc), FileSize = 7521358 },
            new() { RepositoryId = 2, Version = "2011.01.18.0000", BuildTime = new(2011, 01, 18, 0, 0, 0, DateTimeKind.Utc), FileSize = 9954265 },
            new() { RepositoryId = 2, Version = "2011.02.01.0000", BuildTime = new(2011, 02, 01, 0, 0, 0, DateTimeKind.Utc), FileSize = 11632816 },
            new() { RepositoryId = 2, Version = "2011.02.10.0000", BuildTime = new(2011, 02, 10, 0, 0, 0, DateTimeKind.Utc), FileSize = 11714096 },
            new() { RepositoryId = 2, Version = "2011.03.01.0000", BuildTime = new(2011, 03, 01, 0, 0, 0, DateTimeKind.Utc), FileSize = 77464101 },
            new() { RepositoryId = 2, Version = "2011.03.24.0000", BuildTime = new(2011, 03, 24, 0, 0, 0, DateTimeKind.Utc), FileSize = 108923937 },
            new() { RepositoryId = 2, Version = "2011.03.30.0000", BuildTime = new(2011, 03, 30, 0, 0, 0, DateTimeKind.Utc), FileSize = 109010880 },
            new() { RepositoryId = 2, Version = "2011.04.13.0000", BuildTime = new(2011, 04, 13, 0, 0, 0, DateTimeKind.Utc), FileSize = 341603850 },
            new() { RepositoryId = 2, Version = "2011.04.21.0000", BuildTime = new(2011, 04, 21, 0, 0, 0, DateTimeKind.Utc), FileSize = 343579198 },
            new() { RepositoryId = 2, Version = "2011.05.19.0000", BuildTime = new(2011, 05, 19, 0, 0, 0, DateTimeKind.Utc), FileSize = 344239925 },
            new() { RepositoryId = 2, Version = "2011.06.10.0000", BuildTime = new(2011, 06, 10, 0, 0, 0, DateTimeKind.Utc), FileSize = 344334860 },
            new() { RepositoryId = 2, Version = "2011.07.20.0000", BuildTime = new(2011, 07, 20, 0, 0, 0, DateTimeKind.Utc), FileSize = 584926805 },
            new() { RepositoryId = 2, Version = "2011.07.26.0000", BuildTime = new(2011, 07, 26, 0, 0, 0, DateTimeKind.Utc), FileSize = 7649141 },
            new() { RepositoryId = 2, Version = "2011.08.05.0000", BuildTime = new(2011, 08, 05, 0, 0, 0, DateTimeKind.Utc), FileSize = 152064532 },
            new() { RepositoryId = 2, Version = "2011.08.09.0000", BuildTime = new(2011, 08, 09, 0, 0, 0, DateTimeKind.Utc), FileSize = 8573687 },
            new() { RepositoryId = 2, Version = "2011.08.16.0000", BuildTime = new(2011, 08, 16, 0, 0, 0, DateTimeKind.Utc), FileSize = 6118907 },
            new() { RepositoryId = 2, Version = "2011.10.04.0000", BuildTime = new(2011, 10, 04, 0, 0, 0, DateTimeKind.Utc), FileSize = 677633296 },
            new() { RepositoryId = 2, Version = "2011.10.12.0001", BuildTime = new(2011, 10, 12, 0, 0, 0, DateTimeKind.Utc), FileSize = 28941655 },
            new() { RepositoryId = 2, Version = "2011.10.27.0000", BuildTime = new(2011, 10, 27, 0, 0, 0, DateTimeKind.Utc), FileSize = 29179764 },
            new() { RepositoryId = 2, Version = "2011.12.14.0000", BuildTime = new(2011, 12, 14, 0, 0, 0, DateTimeKind.Utc), FileSize = 374617428 },
            new() { RepositoryId = 2, Version = "2011.12.23.0000", BuildTime = new(2011, 12, 23, 0, 0, 0, DateTimeKind.Utc), FileSize = 22363713 },
            new() { RepositoryId = 2, Version = "2012.01.18.0000", BuildTime = new(2012, 01, 18, 0, 0, 0, DateTimeKind.Utc), FileSize = 48998794 },
            new() { RepositoryId = 2, Version = "2012.01.24.0000", BuildTime = new(2012, 01, 24, 0, 0, 0, DateTimeKind.Utc), FileSize = 49126606 },
            new() { RepositoryId = 2, Version = "2012.01.31.0000", BuildTime = new(2012, 01, 31, 0, 0, 0, DateTimeKind.Utc), FileSize = 49536396 },
            new() { RepositoryId = 2, Version = "2012.03.07.0000", BuildTime = new(2012, 03, 07, 0, 0, 0, DateTimeKind.Utc), FileSize = 320630782 },
            new() { RepositoryId = 2, Version = "2012.03.09.0000", BuildTime = new(2012, 03, 09, 0, 0, 0, DateTimeKind.Utc), FileSize = 8312819 },
            new() { RepositoryId = 2, Version = "2012.03.22.0000", BuildTime = new(2012, 03, 22, 0, 0, 0, DateTimeKind.Utc), FileSize = 22027738 },
            new() { RepositoryId = 2, Version = "2012.03.29.0000", BuildTime = new(2012, 03, 29, 0, 0, 0, DateTimeKind.Utc), FileSize = 8322920 },
            new() { RepositoryId = 2, Version = "2012.04.04.0000", BuildTime = new(2012, 04, 04, 0, 0, 0, DateTimeKind.Utc), FileSize = 8678570 },
            new() { RepositoryId = 2, Version = "2012.04.23.0001", BuildTime = new(2012, 04, 23, 0, 0, 0, DateTimeKind.Utc), FileSize = 289511791 },
            new() { RepositoryId = 2, Version = "2012.05.08.0000", BuildTime = new(2012, 05, 08, 0, 0, 0, DateTimeKind.Utc), FileSize = 27266546 },
            new() { RepositoryId = 2, Version = "2012.05.15.0000", BuildTime = new(2012, 05, 15, 0, 0, 0, DateTimeKind.Utc), FileSize = 27416023 },
            new() { RepositoryId = 2, Version = "2012.05.22.0000", BuildTime = new(2012, 05, 22, 0, 0, 0, DateTimeKind.Utc), FileSize = 27742726 },
            new() { RepositoryId = 2, Version = "2012.06.06.0000", BuildTime = new(2012, 06, 06, 0, 0, 0, DateTimeKind.Utc), FileSize = 129984024 },
            new() { RepositoryId = 2, Version = "2012.06.19.0000", BuildTime = new(2012, 06, 19, 0, 0, 0, DateTimeKind.Utc), FileSize = 133434217 },
            new() { RepositoryId = 2, Version = "2012.06.26.0000", BuildTime = new(2012, 06, 26, 0, 0, 0, DateTimeKind.Utc), FileSize = 133581048 },
            new() { RepositoryId = 2, Version = "2012.07.21.0000", BuildTime = new(2012, 07, 21, 0, 0, 0, DateTimeKind.Utc), FileSize = 253224781 },
            new() { RepositoryId = 2, Version = "2012.08.10.0000", BuildTime = new(2012, 08, 10, 0, 0, 0, DateTimeKind.Utc), FileSize = 42851112 },
            new() { RepositoryId = 2, Version = "2012.09.06.0000", BuildTime = new(2012, 09, 06, 0, 0, 0, DateTimeKind.Utc), FileSize = 20566711 },
            new() { RepositoryId = 2, Version = "2012.09.19.0001", BuildTime = new(2012, 09, 19, 0, 0, 0, DateTimeKind.Utc), FileSize = 20874726 }
        ]);
    }
}
