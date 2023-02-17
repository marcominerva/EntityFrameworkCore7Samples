﻿// <auto-generated />
using System;
using MappingSamples.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MappingSamples.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230217144234_TPC")]
    partial class TPC
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MappingSamples.DataAccessLayer.Entities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("MappingSamples.DataAccessLayer.Entities.Student", b =>
                {
                    b.HasBaseType("MappingSamples.DataAccessLayer.Entities.Person");

                    b.Property<string>("IdentificationNumber")
                        .IsRequired()
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnType("varchar(6)");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("MappingSamples.DataAccessLayer.Entities.Worker", b =>
                {
                    b.HasBaseType("MappingSamples.DataAccessLayer.Entities.Person");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.ToTable("Workers");
                });
#pragma warning restore 612, 618
        }
    }
}
