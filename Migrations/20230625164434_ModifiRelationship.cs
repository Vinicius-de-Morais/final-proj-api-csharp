using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api_projeto_final.Migrations
{
    /// <inheritdoc />
    public partial class ModifiRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassModifiers_CadAbilityScore_CadAbilityScoreId",
                table: "ClassModifiers");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassModifiers_Classes_ClassId",
                table: "ClassModifiers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassModifiers",
                table: "ClassModifiers");

            migrationBuilder.RenameTable(
                name: "ClassModifiers",
                newName: "ClassesModifiers");

            migrationBuilder.RenameIndex(
                name: "IX_ClassModifiers_ClassId",
                table: "ClassesModifiers",
                newName: "IX_ClassesModifiers_ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassModifiers_CadAbilityScoreId",
                table: "ClassesModifiers",
                newName: "IX_ClassesModifiers_CadAbilityScoreId");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "expires_at",
                table: "tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 6, 25, 20, 44, 34, 202, DateTimeKind.Unspecified).AddTicks(8535), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 6, 25, 7, 12, 16, 643, DateTimeKind.Unspecified).AddTicks(2588), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_at",
                table: "tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 6, 25, 16, 44, 34, 202, DateTimeKind.Unspecified).AddTicks(7680), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 6, 25, 3, 12, 16, 643, DateTimeKind.Unspecified).AddTicks(685), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassesModifiers",
                table: "ClassesModifiers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RacesModifiers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RaceId = table.Column<int>(type: "integer", nullable: false),
                    CadAbilityScoreId = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RacesModifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RacesModifiers_CadAbilityScore_CadAbilityScoreId",
                        column: x => x.CadAbilityScoreId,
                        principalTable: "CadAbilityScore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RacesModifiers_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RacesModifiers_CadAbilityScoreId",
                table: "RacesModifiers",
                column: "CadAbilityScoreId");

            migrationBuilder.CreateIndex(
                name: "IX_RacesModifiers_RaceId",
                table: "RacesModifiers",
                column: "RaceId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassesModifiers_CadAbilityScore_CadAbilityScoreId",
                table: "ClassesModifiers");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassesModifiers_Classes_ClassId",
                table: "ClassesModifiers");

            migrationBuilder.DropTable(
                name: "RacesModifiers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassesModifiers",
                table: "ClassesModifiers");

            migrationBuilder.RenameTable(
                name: "ClassesModifiers",
                newName: "ClassModifiers");

            migrationBuilder.RenameIndex(
                name: "IX_ClassesModifiers_ClassId",
                table: "ClassModifiers",
                newName: "IX_ClassModifiers_ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassesModifiers_CadAbilityScoreId",
                table: "ClassModifiers",
                newName: "IX_ClassModifiers_CadAbilityScoreId");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "expires_at",
                table: "tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 6, 25, 7, 12, 16, 643, DateTimeKind.Unspecified).AddTicks(2588), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 6, 25, 20, 44, 34, 202, DateTimeKind.Unspecified).AddTicks(8535), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_at",
                table: "tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 6, 25, 3, 12, 16, 643, DateTimeKind.Unspecified).AddTicks(685), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 6, 25, 16, 44, 34, 202, DateTimeKind.Unspecified).AddTicks(7680), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassModifiers",
                table: "ClassModifiers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassModifiers_CadAbilityScore_CadAbilityScoreId",
                table: "ClassModifiers",
                column: "CadAbilityScoreId",
                principalTable: "CadAbilityScore",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassModifiers_Classes_ClassId",
                table: "ClassModifiers",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
