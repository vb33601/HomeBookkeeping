﻿// <auto-generated />
using System;
using HomeBookkeepingWebApi.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HomeBookkeepingWebApi.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220313082720_AddToDb")]
    partial class AddToDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HomeBookkeepingWebApi.Domain.Entity.СreditСard", b =>
                {
                    b.Property<int>("СreditСardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("СreditСardId"), 1L, 1);

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("L_Account")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Sum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserFullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("СreditСardId");

                    b.HasIndex("UserId");

                    b.ToTable("СreditСard");

                    b.HasData(
                        new
                        {
                            СreditСardId = 1,
                            BankName = "Сбер",
                            L_Account = "40817810100011234567",
                            Number = "0000 0000 0000 0000",
                            Sum = 8000m,
                            UserFullName = "Горлов Андрей",
                            UserId = 1
                        },
                        new
                        {
                            СreditСardId = 2,
                            BankName = "ВТБ",
                            L_Account = "40817810200021234568",
                            Number = "0000 0000 0000 0001",
                            Sum = 3000m,
                            UserFullName = "Горлов Андрей",
                            UserId = 1
                        },
                        new
                        {
                            СreditСardId = 3,
                            BankName = "Сбер",
                            L_Account = "40817810300031234569",
                            Number = "0000 0000 0000 0002",
                            Sum = 5000m,
                            UserFullName = "Горлова Ольга",
                            UserId = 2
                        },
                        new
                        {
                            СreditСardId = 4,
                            BankName = "Мир",
                            L_Account = "40817810400041234560",
                            Number = "0000 0000 0000 0000",
                            Sum = 3000m,
                            UserFullName = "Горлова Ольга",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("HomeBookkeepingWebApi.Domain.Entity.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOperations")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumberCardUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecipientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Sum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserFullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Transaction");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Рестораны и кафе",
                            DateOperations = new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberCardUser = "0000 0000 0000 0000",
                            RecipientName = "YABLONKA 9",
                            Sum = 100m,
                            UserFullName = "Горлов Андрей"
                        },
                        new
                        {
                            Id = 2,
                            Category = "Рестораны и кафе",
                            DateOperations = new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberCardUser = "0000 0000 0000 0000",
                            RecipientName = "KFS",
                            Sum = 50m,
                            UserFullName = "Горлов Андрей"
                        },
                        new
                        {
                            Id = 3,
                            Category = "Комунальные платежи, связь, интернет.",
                            DateOperations = new DateTime(2022, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberCardUser = "0000 0000 0000 0001",
                            RecipientName = "DOM.RU PENZA",
                            Sum = 1000m,
                            UserFullName = "Горлов Андрей"
                        },
                        new
                        {
                            Id = 4,
                            Category = "Здоровье и красота",
                            DateOperations = new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberCardUser = "0000 0000 0000 0002",
                            RecipientName = "Летуаль",
                            Sum = 70m,
                            UserFullName = "Горлова Ольга"
                        },
                        new
                        {
                            Id = 5,
                            Category = "Летуаль",
                            DateOperations = new DateTime(2022, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberCardUser = "0000 0000 0000 0002",
                            RecipientName = "Летуаль",
                            Sum = 300m,
                            UserFullName = "Горлова Ольга"
                        },
                        new
                        {
                            Id = 6,
                            Category = "Одежда и аксессуары",
                            DateOperations = new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberCardUser = "0000 0000 0000 0000",
                            RecipientName = "OOO Dom Knigi",
                            Sum = 150m,
                            UserFullName = "Горлова Ольга"
                        });
                });

            modelBuilder.Entity("HomeBookkeepingWebApi.Domain.Entity.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "a@gmail.com",
                            FullName = "Горлов Андрей",
                            PhoneNumber = "013579"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "o@gmail.com",
                            FullName = "Горлова Ольга",
                            PhoneNumber = "013789"
                        });
                });

            modelBuilder.Entity("HomeBookkeepingWebApi.Domain.Entity.СreditСard", b =>
                {
                    b.HasOne("HomeBookkeepingWebApi.Domain.Entity.User", null)
                        .WithMany("СreditСards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HomeBookkeepingWebApi.Domain.Entity.User", b =>
                {
                    b.Navigation("СreditСards");
                });
#pragma warning restore 612, 618
        }
    }
}
