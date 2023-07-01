using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_projeto_final.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCharacter : Migration
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
                name: "FK_CharacterSkills_CadAbilityScore_CadSkillId",
                table: "CharacterSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSpells_CadAbilityScore_CadSpellId",
                table: "CharacterSpells");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSpells_Characters_CharacterId",
                table: "CharacterSpells");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassesModifiers_CadAbilityScore_CadAbilityScoreId",
                table: "ClassesModifiers");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassesModifiers_Classes_ClassId",
                table: "ClassesModifiers");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Characters_CharacterId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_RacesModifiers_Races_RaceId",
                table: "RacesModifiers");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "expires_at",
                table: "tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 6, 29, 1, 37, 38, 812, DateTimeKind.Unspecified).AddTicks(8748), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 6, 26, 0, 5, 52, 406, DateTimeKind.Unspecified).AddTicks(8630), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_at",
                table: "tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 6, 28, 21, 37, 38, 812, DateTimeKind.Unspecified).AddTicks(4175), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 6, 25, 20, 5, 52, 406, DateTimeKind.Unspecified).AddTicks(7767), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<int>(
                name: "CharacterId",
                table: "Equipment",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "ClassesModifiers",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CadAbilityScoreId",
                table: "ClassesModifiers",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Level",
                table: "CharacterSpells",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CharacterId",
                table: "CharacterSpells",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CadSpellId",
                table: "CharacterSpells",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CadSkillId",
                table: "CharacterSkills",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Characters",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Value",
                table: "CharacterAbilityScores",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CharacterId",
                table: "CharacterAbilityScores",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CadAbilityScoreId",
                table: "CharacterAbilityScores",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_UserId",
                table: "Characters",
                column: "UserId");

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
                name: "FK_Characters_users_UserId",
                table: "Characters",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSkills_CadAbilityScore_CadSkillId",
                table: "CharacterSkills",
                column: "CadSkillId",
                principalTable: "CadAbilityScore",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSpells_CadAbilityScore_CadSpellId",
                table: "CharacterSpells",
                column: "CadSpellId",
                principalTable: "CadAbilityScore",
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
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassesModifiers_Classes_ClassId",
                table: "ClassesModifiers",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Characters_CharacterId",
                table: "Equipment",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RacesModifiers_Races_RaceId",
                table: "RacesModifiers",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "Id");
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
                name: "FK_Characters_users_UserId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSkills_CadAbilityScore_CadSkillId",
                table: "CharacterSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSpells_CadAbilityScore_CadSpellId",
                table: "CharacterSpells");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSpells_Characters_CharacterId",
                table: "CharacterSpells");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassesModifiers_CadAbilityScore_CadAbilityScoreId",
                table: "ClassesModifiers");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassesModifiers_Classes_ClassId",
                table: "ClassesModifiers");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Characters_CharacterId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_RacesModifiers_Races_RaceId",
                table: "RacesModifiers");

            migrationBuilder.DropIndex(
                name: "IX_Characters_UserId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Characters");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "expires_at",
                table: "tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 6, 26, 0, 5, 52, 406, DateTimeKind.Unspecified).AddTicks(8630), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 6, 29, 1, 37, 38, 812, DateTimeKind.Unspecified).AddTicks(8748), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_at",
                table: "tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 6, 25, 20, 5, 52, 406, DateTimeKind.Unspecified).AddTicks(7767), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 6, 28, 21, 37, 38, 812, DateTimeKind.Unspecified).AddTicks(4175), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<int>(
                name: "CharacterId",
                table: "Equipment",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "ClassesModifiers",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CadAbilityScoreId",
                table: "ClassesModifiers",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Level",
                table: "CharacterSpells",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CharacterId",
                table: "CharacterSpells",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CadSpellId",
                table: "CharacterSpells",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CadSkillId",
                table: "CharacterSkills",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Value",
                table: "CharacterAbilityScores",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CharacterId",
                table: "CharacterAbilityScores",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CadAbilityScoreId",
                table: "CharacterAbilityScores",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

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
                name: "FK_CharacterSkills_CadAbilityScore_CadSkillId",
                table: "CharacterSkills",
                column: "CadSkillId",
                principalTable: "CadAbilityScore",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSpells_CadAbilityScore_CadSpellId",
                table: "CharacterSpells",
                column: "CadSpellId",
                principalTable: "CadAbilityScore",
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
                name: "FK_ClassesModifiers_Classes_ClassId",
                table: "ClassesModifiers",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Characters_CharacterId",
                table: "Equipment",
                column: "CharacterId",
                principalTable: "Characters",
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
    }
}
