using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_projeto_final.Migrations
{
    /// <inheritdoc />
    public partial class EditClassModifires : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "expires_at",
                table: "tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 6, 25, 7, 12, 16, 643, DateTimeKind.Unspecified).AddTicks(2588), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 6, 24, 6, 34, 33, 337, DateTimeKind.Unspecified).AddTicks(968), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_at",
                table: "tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 6, 25, 3, 12, 16, 643, DateTimeKind.Unspecified).AddTicks(685), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 6, 24, 2, 34, 33, 336, DateTimeKind.Unspecified).AddTicks(9492), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "ClassModifiers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "ClassModifiers");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "expires_at",
                table: "tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 6, 24, 6, 34, 33, 337, DateTimeKind.Unspecified).AddTicks(968), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 6, 25, 7, 12, 16, 643, DateTimeKind.Unspecified).AddTicks(2588), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_at",
                table: "tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 6, 24, 2, 34, 33, 336, DateTimeKind.Unspecified).AddTicks(9492), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 6, 25, 3, 12, 16, 643, DateTimeKind.Unspecified).AddTicks(685), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
