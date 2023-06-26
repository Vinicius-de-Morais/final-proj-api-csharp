using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_projeto_final.Migrations
{
    /// <inheritdoc />
    public partial class ModifiRelationship2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "expires_at",
                table: "tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 6, 25, 23, 16, 42, 301, DateTimeKind.Unspecified).AddTicks(8926), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 6, 25, 20, 44, 34, 202, DateTimeKind.Unspecified).AddTicks(8535), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_at",
                table: "tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 6, 25, 19, 16, 42, 301, DateTimeKind.Unspecified).AddTicks(7368), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 6, 25, 16, 44, 34, 202, DateTimeKind.Unspecified).AddTicks(7680), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<int>(
                name: "RaceId",
                table: "RacesModifiers",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "expires_at",
                table: "tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 6, 25, 20, 44, 34, 202, DateTimeKind.Unspecified).AddTicks(8535), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 6, 25, 23, 16, 42, 301, DateTimeKind.Unspecified).AddTicks(8926), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_at",
                table: "tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 6, 25, 16, 44, 34, 202, DateTimeKind.Unspecified).AddTicks(7680), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 6, 25, 19, 16, 42, 301, DateTimeKind.Unspecified).AddTicks(7368), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<int>(
                name: "RaceId",
                table: "RacesModifiers",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
