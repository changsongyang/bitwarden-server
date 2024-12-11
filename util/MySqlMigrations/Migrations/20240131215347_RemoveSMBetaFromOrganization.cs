﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bit.MySqlMigrations.Migrations;

/// <inheritdoc />
public partial class RemoveSMBetaFromOrganization : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(name: "SecretsManagerBeta", table: "Organization");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<bool>(
            name: "SecretsManagerBeta",
            table: "Organization",
            type: "tinyint(1)",
            nullable: false,
            defaultValue: false
        );
    }
}
