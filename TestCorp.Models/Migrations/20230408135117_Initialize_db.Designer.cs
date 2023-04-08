﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TestCorp.Domain.Data;

#nullable disable

namespace TestCorp.Domain.Migrations
{
    [DbContext(typeof(Test4CreateDbContext))]
    [Migration("20230408135117_Initialize_db")]
    partial class Initialize_db
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

            modelBuilder.Entity("TestCorp.Domain.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("company");
                });

            modelBuilder.Entity("TestCorp.Domain.Models.CompanyEmployee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer");

                    b.HasKey("EmployeeId", "CompanyId");

                    b.HasIndex("CompanyId");

                    b.ToTable("company_employee");
                });

            modelBuilder.Entity("TestCorp.Domain.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<byte>("Title")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("employee");
                });

            modelBuilder.Entity("TestCorp.Domain.Models.SystemLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("Changeset")
                        .HasColumnType("text");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<byte>("Event")
                        .HasColumnType("smallint");

                    b.Property<int>("ResourceType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("systemlog");
                });

            modelBuilder.Entity("TestCorp.Domain.Models.CompanyEmployee", b =>
                {
                    b.HasOne("TestCorp.Domain.Models.Company", "Company")
                        .WithMany("CompanyEmployees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestCorp.Domain.Models.Employee", "Employee")
                        .WithMany("CompanyEmployees")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("TestCorp.Domain.Models.Company", b =>
                {
                    b.Navigation("CompanyEmployees");
                });

            modelBuilder.Entity("TestCorp.Domain.Models.Employee", b =>
                {
                    b.Navigation("CompanyEmployees");
                });
#pragma warning restore 612, 618
        }
    }
}
