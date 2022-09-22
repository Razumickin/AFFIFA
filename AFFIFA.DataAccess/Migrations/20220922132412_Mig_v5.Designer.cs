﻿// <auto-generated />
using System;
using AFFIFA.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AFFIFA.DataAccess.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220922132412_Mig_v5")]
    partial class Mig_v5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AFFIFA.Domain.Entities.Campeonato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Campeonatos");
                });

            modelBuilder.Entity("AFFIFA.Domain.Entities.Equipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Abreviacao")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Equipes");
                });

            modelBuilder.Entity("AFFIFA.Domain.Entities.Jogador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("EquipeId")
                        .HasColumnType("int");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeCurto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SofifaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EquipeId");

                    b.ToTable("Jogadores");
                });

            modelBuilder.Entity("AFFIFA.Domain.Entities.Partida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CampeonatoId")
                        .HasColumnType("int");

                    b.Property<int?>("GolsMandante")
                        .HasColumnType("int");

                    b.Property<int?>("GolsVisitante")
                        .HasColumnType("int");

                    b.Property<int>("MandanteId")
                        .HasColumnType("int");

                    b.Property<int>("VisitanteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CampeonatoId");

                    b.HasIndex("MandanteId");

                    b.HasIndex("VisitanteId");

                    b.ToTable("Partidas");
                });

            modelBuilder.Entity("CampeonatoEquipe", b =>
                {
                    b.Property<int>("CampeonatosId")
                        .HasColumnType("int");

                    b.Property<int>("EquipesId")
                        .HasColumnType("int");

                    b.HasKey("CampeonatosId", "EquipesId");

                    b.HasIndex("EquipesId");

                    b.ToTable("CampeonatoEquipe");
                });

            modelBuilder.Entity("AFFIFA.Domain.Entities.Jogador", b =>
                {
                    b.HasOne("AFFIFA.Domain.Entities.Equipe", "Equipe")
                        .WithMany()
                        .HasForeignKey("EquipeId");

                    b.Navigation("Equipe");
                });

            modelBuilder.Entity("AFFIFA.Domain.Entities.Partida", b =>
                {
                    b.HasOne("AFFIFA.Domain.Entities.Campeonato", "Campeonato")
                        .WithMany()
                        .HasForeignKey("CampeonatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AFFIFA.Domain.Entities.Equipe", "Mandante")
                        .WithMany()
                        .HasForeignKey("MandanteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AFFIFA.Domain.Entities.Equipe", "Visitante")
                        .WithMany()
                        .HasForeignKey("VisitanteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Campeonato");

                    b.Navigation("Mandante");

                    b.Navigation("Visitante");
                });

            modelBuilder.Entity("CampeonatoEquipe", b =>
                {
                    b.HasOne("AFFIFA.Domain.Entities.Campeonato", null)
                        .WithMany()
                        .HasForeignKey("CampeonatosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AFFIFA.Domain.Entities.Equipe", null)
                        .WithMany()
                        .HasForeignKey("EquipesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
