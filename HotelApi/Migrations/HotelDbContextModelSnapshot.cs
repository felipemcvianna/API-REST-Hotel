﻿// <auto-generated />
using System;
using HotelApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelApi.Migrations
{
    [DbContext(typeof(HotelDbContext))]
    partial class HotelDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("HotelApi.Context.Hospedes.Models.Hospede", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("QuartoId")
                        .HasColumnType("int");

                    b.Property<int?>("ReservaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuartoId");

                    b.HasIndex("ReservaId");

                    b.ToTable("Hospedes");
                });

            modelBuilder.Entity("HotelApi.Context.Quarto.Models.Quarto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("SalvarVagas")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Vagas")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Quartos");
                });

            modelBuilder.Entity("HotelApi.Context.Reserva.Models.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("CheckInConcluido")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("CheckOut")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("CheckOutConcluido")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("QuartoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuartoId")
                        .IsUnique();

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("HotelApi.Context.Hospedes.Models.Hospede", b =>
                {
                    b.HasOne("HotelApi.Context.Quarto.Models.Quarto", null)
                        .WithMany("Hospedes")
                        .HasForeignKey("QuartoId");

                    b.HasOne("HotelApi.Context.Reserva.Models.Reserva", null)
                        .WithMany("Hospedes")
                        .HasForeignKey("ReservaId");
                });

            modelBuilder.Entity("HotelApi.Context.Reserva.Models.Reserva", b =>
                {
                    b.HasOne("HotelApi.Context.Quarto.Models.Quarto", "Quarto")
                        .WithOne("Reserva")
                        .HasForeignKey("HotelApi.Context.Reserva.Models.Reserva", "QuartoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quarto");
                });

            modelBuilder.Entity("HotelApi.Context.Quarto.Models.Quarto", b =>
                {
                    b.Navigation("Hospedes");

                    b.Navigation("Reserva");
                });

            modelBuilder.Entity("HotelApi.Context.Reserva.Models.Reserva", b =>
                {
                    b.Navigation("Hospedes");
                });
#pragma warning restore 612, 618
        }
    }
}
