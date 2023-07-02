using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_projeto_final.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTheDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterAbilityScores_CadAbilityScore_CadAbilityScoreId",
                table: "CharacterAbilityScores");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterAbilityScores_Characters_CharacterId",
                table: "CharacterAbilityScores");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSkills_Characters_CharacterId",
                table: "CharacterSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSpells_Characters_CharacterId",
                table: "CharacterSpells");

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
                defaultValue: new DateTimeOffset(new DateTime(2023, 7, 2, 23, 13, 16, 641, DateTimeKind.Unspecified).AddTicks(6665), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 7, 1, 1, 58, 33, 534, DateTimeKind.Unspecified).AddTicks(8627), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_at",
                table: "tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 7, 2, 19, 13, 16, 641, DateTimeKind.Unspecified).AddTicks(5037), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 6, 30, 21, 58, 33, 534, DateTimeKind.Unspecified).AddTicks(6417), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Characters",
                type: "varchar(256)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(256)");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterAbilityScores_CadAbilityScore_CadAbilityScoreId",
                table: "CharacterAbilityScores",
                column: "CadAbilityScoreId",
                principalTable: "CadAbilityScore",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterAbilityScores_Characters_CharacterId",
                table: "CharacterAbilityScores",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSkills_Characters_CharacterId",
                table: "CharacterSkills",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSpells_Characters_CharacterId",
                table: "CharacterSpells",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterAbilityScores_CadAbilityScore_CadAbilityScoreId",
                table: "CharacterAbilityScores");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterAbilityScores_Characters_CharacterId",
                table: "CharacterAbilityScores");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSkills_Characters_CharacterId",
                table: "CharacterSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSpells_Characters_CharacterId",
                table: "CharacterSpells");

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
                defaultValue: new DateTimeOffset(new DateTime(2023, 7, 1, 1, 58, 33, 534, DateTimeKind.Unspecified).AddTicks(8627), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 7, 2, 23, 13, 16, 641, DateTimeKind.Unspecified).AddTicks(6665), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_at",
                table: "tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 6, 30, 21, 58, 33, 534, DateTimeKind.Unspecified).AddTicks(6417), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 7, 2, 19, 13, 16, 641, DateTimeKind.Unspecified).AddTicks(5037), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Characters",
                type: "varchar(256)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterAbilityScores_CadAbilityScore_CadAbilityScoreId",
                table: "CharacterAbilityScores",
                column: "CadAbilityScoreId",
                principalTable: "CadAbilityScore",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterAbilityScores_Characters_CharacterId",
                table: "CharacterAbilityScores",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSkills_Characters_CharacterId",
                table: "CharacterSkills",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSpells_Characters_CharacterId",
                table: "CharacterSpells",
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
    }
}
