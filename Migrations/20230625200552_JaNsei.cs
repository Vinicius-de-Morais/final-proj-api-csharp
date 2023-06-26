using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_projeto_final.Migrations
{
    /// <inheritdoc />
    public partial class JaNsei : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassesModifiers_CadAbilityScore_CadAbilityScoreId",
                table: "ClassesModifiers");

            migrationBuilder.DropForeignKey(
                name: "FK_RacesModifiers_CadAbilityScore_CadAbilityScoreId",
                table: "RacesModifiers");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "expires_at",
                table: "tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 6, 26, 0, 5, 52, 406, DateTimeKind.Unspecified).AddTicks(8630), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 6, 25, 23, 38, 29, 873, DateTimeKind.Unspecified).AddTicks(647), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_at",
                table: "tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 6, 25, 20, 5, 52, 406, DateTimeKind.Unspecified).AddTicks(7767), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 6, 25, 19, 38, 29, 872, DateTimeKind.Unspecified).AddTicks(9636), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<int>(
                name: "CadAbilityScoreId",
                table: "RacesModifiers",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassesModifiers_CadAbilityScore_CadAbilityScoreId",
                table: "ClassesModifiers",
                column: "CadAbilityScoreId",
                principalTable: "CadAbilityScore",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RacesModifiers_CadAbilityScore_CadAbilityScoreId",
                table: "RacesModifiers",
                column: "CadAbilityScoreId",
                principalTable: "CadAbilityScore",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassesModifiers_CadAbilityScore_CadAbilityScoreId",
                table: "ClassesModifiers");

            migrationBuilder.DropForeignKey(
                name: "FK_RacesModifiers_CadAbilityScore_CadAbilityScoreId",
                table: "RacesModifiers");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "expires_at",
                table: "tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 6, 25, 23, 38, 29, 873, DateTimeKind.Unspecified).AddTicks(647), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 6, 26, 0, 5, 52, 406, DateTimeKind.Unspecified).AddTicks(8630), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_at",
                table: "tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 6, 25, 19, 38, 29, 872, DateTimeKind.Unspecified).AddTicks(9636), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 6, 25, 20, 5, 52, 406, DateTimeKind.Unspecified).AddTicks(7767), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<int>(
                name: "CadAbilityScoreId",
                table: "RacesModifiers",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassesModifiers_CadAbilityScore_CadAbilityScoreId",
                table: "ClassesModifiers",
                column: "CadAbilityScoreId",
                principalTable: "CadAbilityScore",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RacesModifiers_CadAbilityScore_CadAbilityScoreId",
                table: "RacesModifiers",
                column: "CadAbilityScoreId",
                principalTable: "CadAbilityScore",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
