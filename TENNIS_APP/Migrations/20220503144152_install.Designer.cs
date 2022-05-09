﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TENNIS_APP.Models;

namespace TENNIS_APP.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220503144152_install")]
    partial class install
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TENNIS_APP.Models.Gain", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ANNEE")
                        .HasColumnType("int");

                    b.Property<int?>("ANNEE_TOURNOI")
                        .HasColumnType("int");

                    b.Property<int>("ID_JOUEUR")
                        .HasColumnType("int");

                    b.Property<int>("Nom_SPONSOR")
                        .HasColumnType("int");

                    b.Property<int>("prime")
                        .HasColumnName("PRIME")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("ANNEE_TOURNOI");

                    b.HasIndex("ID_JOUEUR");

                    b.HasIndex("Nom_SPONSOR");

                    b.ToTable("Gain","dbo");
                });

            modelBuilder.Entity("TENNIS_APP.Models.Joueur", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnName("AGE")
                        .HasColumnType("int");

                    b.Property<string>("Nationalite")
                        .HasColumnName("NATIONALITE")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnName("NOM")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("prenom")
                        .IsRequired()
                        .HasColumnName("PRENOM")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("id");

                    b.ToTable("joueurs");
                });

            modelBuilder.Entity("TENNIS_APP.Models.Ranking", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ID_Player_RANK")
                        .HasColumnType("int");

                    b.Property<int>("RANK_PLAYER")
                        .HasColumnType("int");

                    b.Property<string>("Rank")
                        .IsRequired()
                        .HasColumnName("RANK")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("score")
                        .IsRequired()
                        .HasColumnName("SCORE")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("ID_Player_RANK");

                    b.ToTable("RANKING","dbo");
                });

            modelBuilder.Entity("TENNIS_APP.Models.Rencontre", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ID_GAGNANT")
                        .HasColumnType("int");

                    b.Property<int>("ID_Gagant")
                        .HasColumnType("int");

                    b.Property<int>("ID_PERDANT")
                        .HasColumnType("int");

                    b.Property<int>("ID_Tournoi")
                        .HasColumnType("int");

                    b.Property<string>("date_tournoi")
                        .IsRequired()
                        .HasColumnName("Date_Tournoi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("score")
                        .IsRequired()
                        .HasColumnName("SCORE")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("ID_GAGNANT");

                    b.HasIndex("ID_PERDANT");

                    b.HasIndex("ID_Tournoi");

                    b.ToTable("Rencontre","dbo");
                });

            modelBuilder.Entity("TENNIS_APP.Models.Sponsor", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("adress")
                        .IsRequired()
                        .HasColumnName("ADRESS")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<int>("chiffre_daffaire")
                        .HasColumnName("CHIFFRE")
                        .HasColumnType("int");

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnName("NOM")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("id");

                    b.ToTable("Sponsor","dbo");
                });

            modelBuilder.Entity("TENNIS_APP.Models.Subvention", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Montant")
                        .HasColumnName("MONTANT")
                        .HasColumnType("int");

                    b.Property<string>("NAME_SPR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NOM_SPTR")
                        .HasColumnType("int");

                    b.Property<int>("NOM_TR")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("NOM_SPTR");

                    b.HasIndex("NOM_TR");

                    b.ToTable("Subvention","dbo");
                });

            modelBuilder.Entity("TENNIS_APP.Models.Tournoi", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("capacite")
                        .HasColumnName("CAPACITE")
                        .HasColumnType("int");

                    b.Property<int>("date")
                        .HasColumnName("DATE")
                        .HasColumnType("int");

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnName("NOM")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<int>("prix")
                        .HasColumnName("PRIX")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Tournoi","dbo");
                });

            modelBuilder.Entity("TENNIS_APP.Models.Gain", b =>
                {
                    b.HasOne("TENNIS_APP.Models.Tournoi", "annee_tournoi")
                        .WithMany()
                        .HasForeignKey("ANNEE_TOURNOI");

                    b.HasOne("TENNIS_APP.Models.Joueur", "joueur")
                        .WithMany()
                        .HasForeignKey("ID_JOUEUR")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TENNIS_APP.Models.Sponsor", "Nom_sponsor")
                        .WithMany()
                        .HasForeignKey("Nom_SPONSOR")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TENNIS_APP.Models.Ranking", b =>
                {
                    b.HasOne("TENNIS_APP.Models.Joueur", "Player_Rank")
                        .WithMany()
                        .HasForeignKey("ID_Player_RANK");
                });

            modelBuilder.Entity("TENNIS_APP.Models.Rencontre", b =>
                {
                    b.HasOne("TENNIS_APP.Models.Joueur", "gagnant")
                        .WithMany()
                        .HasForeignKey("ID_GAGNANT");

                    b.HasOne("TENNIS_APP.Models.Joueur", "PERDANT")
                        .WithMany()
                        .HasForeignKey("ID_PERDANT")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TENNIS_APP.Models.Tournoi", "tournoi")
                        .WithMany()
                        .HasForeignKey("ID_Tournoi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TENNIS_APP.Models.Subvention", b =>
                {
                    b.HasOne("TENNIS_APP.Models.Sponsor", "NAME_SP")
                        .WithMany()
                        .HasForeignKey("NOM_SPTR");

                    b.HasOne("TENNIS_APP.Models.Tournoi", "Nom_tr")
                        .WithMany()
                        .HasForeignKey("NOM_TR")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}