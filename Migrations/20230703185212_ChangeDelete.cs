using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_projeto_final.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassesModifiers_Classes_ClassId",
                table: "ClassesModifiers");

            migrationBuilder.DropForeignKey(
                name: "FK_RacesModifiers_Races_RaceId",
                table: "RacesModifiers");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "expires_at",
                table: "tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 7, 3, 22, 52, 11, 576, DateTimeKind.Unspecified).AddTicks(689), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 7, 3, 0, 40, 27, 251, DateTimeKind.Unspecified).AddTicks(2940), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_at",
                table: "tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 7, 3, 18, 52, 11, 575, DateTimeKind.Unspecified).AddTicks(9753), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 7, 2, 20, 40, 27, 251, DateTimeKind.Unspecified).AddTicks(639), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_ClassesModifiers_Classes_ClassId",
                table: "ClassesModifiers",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RacesModifiers_Races_RaceId",
                table: "RacesModifiers",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassesModifiers_Classes_ClassId",
                table: "ClassesModifiers");

            migrationBuilder.DropForeignKey(
                name: "FK_RacesModifiers_Races_RaceId",
                table: "RacesModifiers");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "expires_at",
                table: "tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 7, 3, 0, 40, 27, 251, DateTimeKind.Unspecified).AddTicks(2940), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 7, 3, 22, 52, 11, 576, DateTimeKind.Unspecified).AddTicks(689), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_at",
                table: "tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 7, 2, 20, 40, 27, 251, DateTimeKind.Unspecified).AddTicks(639), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 7, 3, 18, 52, 11, 575, DateTimeKind.Unspecified).AddTicks(9753), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_ClassesModifiers_Classes_ClassId",
                table: "ClassesModifiers",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RacesModifiers_Races_RaceId",
                table: "RacesModifiers",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "Id");
        }
    }
}
