﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using api_projeto_final;

#nullable disable

namespace api_projeto_final.Migrations
{
    [DbContext(typeof(DbConnect))]
    partial class DbConnectModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("api_projeto_final.DataModels.CadAbilityScore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CadAbilityScore");
                });

            modelBuilder.Entity("api_projeto_final.DataModels.CadSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CadSkill");
                });

            modelBuilder.Entity("api_projeto_final.DataModels.CadSpell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CadSpell");
                });

            modelBuilder.Entity("api_projeto_final.DataModels.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("integer");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("varchar(256)");

                    b.Property<int>("RaceId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("RaceId");

                    b.HasIndex("UserId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("api_projeto_final.DataModels.CharacterAbilityScore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CadAbilityScoreId")
                        .HasColumnType("integer");

                    b.Property<int?>("CharacterId")
                        .HasColumnType("integer");

                    b.Property<int?>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CadAbilityScoreId");

                    b.HasIndex("CharacterId");

                    b.ToTable("CharacterAbilityScores");
                });

            modelBuilder.Entity("api_projeto_final.DataModels.CharacterSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CadSkillId")
                        .HasColumnType("integer");

                    b.Property<int?>("CharacterId")
                        .HasColumnType("integer");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CadSkillId");

                    b.HasIndex("CharacterId");

                    b.ToTable("CharacterSkills");
                });

            modelBuilder.Entity("api_projeto_final.DataModels.CharacterSpell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CadSpellId")
                        .HasColumnType("integer");

                    b.Property<int?>("CharacterId")
                        .HasColumnType("integer");

                    b.Property<int?>("Level")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CadSpellId");

                    b.HasIndex("CharacterId");

                    b.ToTable("CharacterSpells");
                });

            modelBuilder.Entity("api_projeto_final.DataModels.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("api_projeto_final.DataModels.ClassModifiers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CadAbilityScoreId")
                        .HasColumnType("integer");

                    b.Property<int?>("ClassId")
                        .HasColumnType("integer");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CadAbilityScoreId");

                    b.HasIndex("ClassId");

                    b.ToTable("ClassesModifiers");
                });

            modelBuilder.Entity("api_projeto_final.DataModels.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CharacterId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("api_projeto_final.DataModels.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("api_projeto_final.DataModels.RaceModifiers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CadAbilityScoreId")
                        .HasColumnType("integer");

                    b.Property<int?>("RaceId")
                        .HasColumnType("integer");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CadAbilityScoreId");

                    b.HasIndex("RaceId");

                    b.ToTable("RacesModifiers");
                });

            modelBuilder.Entity("api_projeto_final.DataModels.auth", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("password_hashed")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("password_salt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("userId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("userId")
                        .IsUnique();

                    b.ToTable("auth");
                });

            modelBuilder.Entity("api_projeto_final.DataModels.token", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTimeOffset>("created_at")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2023, 7, 3, 18, 52, 11, 575, DateTimeKind.Unspecified).AddTicks(9753), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<DateTimeOffset>("expires_at")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2023, 7, 3, 22, 52, 11, 576, DateTimeKind.Unspecified).AddTicks(689), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<string>("token_value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("userId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("userId")
                        .IsUnique();

                    b.ToTable("tokens");
                });

            modelBuilder.Entity("api_projeto_final.DataModels.user", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("api_projeto_final.DataModels.Character", b =>
                {
                    b.HasOne("api_projeto_final.DataModels.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api_projeto_final.DataModels.Race", "Race")
                        .WithMany()
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api_projeto_final.DataModels.user", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Race");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api_projeto_final.DataModels.CharacterAbilityScore", b =>
                {
                    b.HasOne("api_projeto_final.DataModels.CadAbilityScore", "CadAbilityScore")
                        .WithMany("CharacterAbilityScore")
                        .HasForeignKey("CadAbilityScoreId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("api_projeto_final.DataModels.Character", "Character")
                        .WithMany("AbilityScore")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("CadAbilityScore");

                    b.Navigation("Character");
                });

            modelBuilder.Entity("api_projeto_final.DataModels.CharacterSkill", b =>
                {
                    b.HasOne("api_projeto_final.DataModels.CadSkill", "CadSkill")
                        .WithMany("characterSkills")
                        .HasForeignKey("CadSkillId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("api_projeto_final.DataModels.Character", "Character")
                        .WithMany("Skills")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("CadSkill");

                    b.Navigation("Character");
                });

            modelBuilder.Entity("api_projeto_final.DataModels.CharacterSpell", b =>
                {
                    b.HasOne("api_projeto_final.DataModels.CadSpell", "CadSpell")
                        .WithMany("characterSpells")
                        .HasForeignKey("CadSpellId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("api_projeto_final.DataModels.Character", "Character")
                        .WithMany("Spells")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("CadSpell");

                    b.Navigation("Character");
                });

            modelBuilder.Entity("api_projeto_final.DataModels.ClassModifiers", b =>
                {
                    b.HasOne("api_projeto_final.DataModels.CadAbilityScore", "CadAbilityScore")
                        .WithMany("ClassModifiers")
                        .HasForeignKey("CadAbilityScoreId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("api_projeto_final.DataModels.Class", "Class")
                        .WithMany("ClassModifiers")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("CadAbilityScore");

                    b.Navigation("Class");
                });

            modelBuilder.Entity("api_projeto_final.DataModels.Equipment", b =>
                {
                    b.HasOne("api_projeto_final.DataModels.Character", "Character")
                        .WithMany("Equipment")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Character");
                });

            modelBuilder.Entity("api_projeto_final.DataModels.RaceModifiers", b =>
                {
                    b.HasOne("api_projeto_final.DataModels.CadAbilityScore", "CadAbilityScore")
                        .WithMany("RaceModifiers")
                        .HasForeignKey("CadAbilityScoreId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("api_projeto_final.DataModels.Race", "Race")
                        .WithMany("RaceModifiers")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("CadAbilityScore");

                    b.Navigation("Race");
                });

            modelBuilder.Entity("api_projeto_final.DataModels.auth", b =>
                {
                    b.HasOne("api_projeto_final.DataModels.user", "user")
                        .WithOne("auth")
                        .HasForeignKey("api_projeto_final.DataModels.auth", "userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("api_projeto_final.DataModels.token", b =>
                {
                    b.HasOne("api_projeto_final.DataModels.user", "user")
                        .WithOne("token")
                        .HasForeignKey("api_projeto_final.DataModels.token", "userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("api_projeto_final.DataModels.CadAbilityScore", b =>
                {
                    b.Navigation("CharacterAbilityScore");

                    b.Navigation("ClassModifiers");

                    b.Navigation("RaceModifiers");
                });

            modelBuilder.Entity("api_projeto_final.DataModels.CadSkill", b =>
                {
                    b.Navigation("characterSkills");
                });

            modelBuilder.Entity("api_projeto_final.DataModels.CadSpell", b =>
                {
                    b.Navigation("characterSpells");
                });

            modelBuilder.Entity("api_projeto_final.DataModels.Character", b =>
                {
                    b.Navigation("AbilityScore");

                    b.Navigation("Equipment");

                    b.Navigation("Skills");

                    b.Navigation("Spells");
                });

            modelBuilder.Entity("api_projeto_final.DataModels.Class", b =>
                {
                    b.Navigation("ClassModifiers");
                });

            modelBuilder.Entity("api_projeto_final.DataModels.Race", b =>
                {
                    b.Navigation("RaceModifiers");
                });

            modelBuilder.Entity("api_projeto_final.DataModels.user", b =>
                {
                    b.Navigation("auth");

                    b.Navigation("token");
                });
#pragma warning restore 612, 618
        }
    }
}
