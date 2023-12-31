﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using URLShortenerService;

#nullable disable

namespace URLShortenerService.Migrations
{
    [DbContext(typeof(ModelDBContext))]
    [Migration("20230819133506_InitialCreate3")]
    partial class InitialCreate3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("URLShortenerService.Models.Record", b =>
                {
                    b.Property<string>("URL")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserLogin")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("URL");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("URLShortenerService.Models.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("URLShortenerService.Models.User", b =>
                {
                    b.Property<string>("Login")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoleID")
                        .HasColumnType("integer");

                    b.HasKey("Login");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
