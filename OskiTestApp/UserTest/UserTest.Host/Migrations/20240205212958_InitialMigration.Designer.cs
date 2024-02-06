﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserTest.Host.Data;

#nullable disable

namespace UserTest.Host.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240205212958_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UserTest.Host.Data.Entities.UserTestEntity", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.Property<bool>("IsTestCompleted")
                        .HasColumnType("bit");

                    b.Property<int?>("Mark")
                        .HasColumnType("int");

                    b.HasKey("UserId", "TestId");

                    b.ToTable("UserTests", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
