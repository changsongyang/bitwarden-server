﻿using Bit.Core.Utilities;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bit.PostgresMigrations.Migrations;

public partial class GenerateDuoSDKVersion4TwoFactorMetadata : Migration
{
    private const string _scriptLocation =
        "PostgresMigrations.HelperScripts.2024-09-05_00_SyncDuoVersionFourMetadataToVersionTwo.psql";

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(CoreHelpers.GetEmbeddedResourceContentsAsync(_scriptLocation));
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        // the changes here are additive and not destructive by adding the v4 data we are not impacting application function.
        // there is no meaningful impact to the application with this migration.
    }
}
