﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using api_projeto_final;

#nullable disable

namespace api_projeto_final.Migrations
{
    [DbContext(typeof(DbConnect))]
    [Migration("20230618012922_temporary")]
    partial class temporary
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2023, 6, 18, 1, 29, 21, 925, DateTimeKind.Unspecified).AddTicks(9519), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<DateTimeOffset>("expires_at")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2023, 6, 18, 5, 29, 21, 926, DateTimeKind.Unspecified).AddTicks(318), new TimeSpan(0, 0, 0, 0, 0)));

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

            modelBuilder.Entity("api_projeto_final.DataModels.user", b =>
                {
                    b.Navigation("auth");

                    b.Navigation("token");
                });
#pragma warning restore 612, 618
        }
    }
}
