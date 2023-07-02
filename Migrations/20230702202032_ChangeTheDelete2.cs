using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_projeto_final.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTheDelete2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSkills_CadSkill_CadSkillId",
                table: "CharacterSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSpells_CadSpell_CadSpellId",
                table: "CharacterSpells");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "expires_at",
                table: "tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 7, 3, 0, 20, 32, 84, DateTimeKind.Unspecified).AddTicks(6306), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 7, 2, 23, 13, 16, 641, DateTimeKind.Unspecified).AddTicks(6665), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_at",
                table: "tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 7, 2, 20, 20, 32, 84, DateTimeKind.Unspecified).AddTicks(5029), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 7, 2, 19, 13, 16, 641, DateTimeKind.Unspecified).AddTicks(5037), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSkills_CadSkill_CadSkillId",
                table: "CharacterSkills",
                column: "CadSkillId",
                principalTable: "CadSkill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSpells_CadSpell_CadSpellId",
                table: "CharacterSpells",
                column: "CadSpellId",
                principalTable: "CadSpell",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSkills_CadSkill_CadSkillId",
                table: "CharacterSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSpells_CadSpell_CadSpellId",
                table: "CharacterSpells");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "expires_at",
                table: "tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 7, 2, 23, 13, 16, 641, DateTimeKind.Unspecified).AddTicks(6665), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 7, 3, 0, 20, 32, 84, DateTimeKind.Unspecified).AddTicks(6306), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_at",
                table: "tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 7, 2, 19, 13, 16, 641, DateTimeKind.Unspecified).AddTicks(5037), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 7, 2, 20, 20, 32, 84, DateTimeKind.Unspecified).AddTicks(5029), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSkills_CadSkill_CadSkillId",
                table: "CharacterSkills",
                column: "CadSkillId",
                principalTable: "CadSkill",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSpells_CadSpell_CadSpellId",
                table: "CharacterSpells",
                column: "CadSpellId",
                principalTable: "CadSpell",
                principalColumn: "Id");
        }
    }
}
