using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_projeto_final.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCharacterAbilityScore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSkills_Characters_CharacterId",
                table: "CharacterSkills");

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
                defaultValue: new DateTimeOffset(new DateTime(2023, 6, 29, 4, 3, 9, 456, DateTimeKind.Unspecified).AddTicks(1247), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 6, 29, 1, 37, 38, 812, DateTimeKind.Unspecified).AddTicks(8748), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_at",
                table: "tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 6, 29, 0, 3, 9, 456, DateTimeKind.Unspecified).AddTicks(363), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 6, 28, 21, 37, 38, 812, DateTimeKind.Unspecified).AddTicks(4175), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<int>(
                name: "CharacterId",
                table: "CharacterSkills",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSkills_Characters_CharacterId",
                table: "CharacterSkills",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSkills_Characters_CharacterId",
                table: "CharacterSkills");

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
                defaultValue: new DateTimeOffset(new DateTime(2023, 6, 29, 1, 37, 38, 812, DateTimeKind.Unspecified).AddTicks(8748), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 6, 29, 4, 3, 9, 456, DateTimeKind.Unspecified).AddTicks(1247), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_at",
                table: "tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 6, 28, 21, 37, 38, 812, DateTimeKind.Unspecified).AddTicks(4175), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 6, 29, 0, 3, 9, 456, DateTimeKind.Unspecified).AddTicks(363), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<int>(
                name: "CharacterId",
                table: "CharacterSkills",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSkills_Characters_CharacterId",
                table: "CharacterSkills",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassesModifiers_CadAbilityScore_CadAbilityScoreId",
                table: "ClassesModifiers",
                column: "CadAbilityScoreId",
                principalTable: "CadAbilityScore",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RacesModifiers_CadAbilityScore_CadAbilityScoreId",
                table: "RacesModifiers",
                column: "CadAbilityScoreId",
                principalTable: "CadAbilityScore",
                principalColumn: "Id");
        }
    }
}
