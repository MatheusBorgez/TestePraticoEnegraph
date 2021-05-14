﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestePretico4.Model;

namespace TestePretico4.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestePretico4.CEP", b =>
                {
                    b.Property<string>("CodigoPostal")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("CidadeId")
                        .HasColumnType("int");

                    b.Property<string>("EstadoUnidadeFederativa")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CodigoPostal");

                    b.HasIndex("CidadeId");

                    b.HasIndex("EstadoUnidadeFederativa");

                    b.ToTable("CEPs");
                });

            modelBuilder.Entity("TestePretico4.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EstadoUnidadeFederativa")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EstadoUnidadeFederativa");

                    b.ToTable("Cidades");
                });

            modelBuilder.Entity("TestePretico4.Estado", b =>
                {
                    b.Property<string>("UnidadeFederativa")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UnidadeFederativa");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("TestePretico4.Pessoa", b =>
                {
                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CEPCodigoPostal")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("CidadeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("EstadoUnidadeFederativa")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CPF");

                    b.HasIndex("CEPCodigoPostal");

                    b.HasIndex("CidadeId");

                    b.HasIndex("EstadoUnidadeFederativa");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("TestePretico4.CEP", b =>
                {
                    b.HasOne("TestePretico4.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId");

                    b.HasOne("TestePretico4.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoUnidadeFederativa");

                    b.Navigation("Cidade");

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("TestePretico4.Cidade", b =>
                {
                    b.HasOne("TestePretico4.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoUnidadeFederativa");

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("TestePretico4.Pessoa", b =>
                {
                    b.HasOne("TestePretico4.CEP", "CEP")
                        .WithMany()
                        .HasForeignKey("CEPCodigoPostal");

                    b.HasOne("TestePretico4.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId");

                    b.HasOne("TestePretico4.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoUnidadeFederativa");

                    b.Navigation("CEP");

                    b.Navigation("Cidade");

                    b.Navigation("Estado");
                });
#pragma warning restore 612, 618
        }
    }
}