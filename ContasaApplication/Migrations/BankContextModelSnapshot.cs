﻿// <auto-generated />
using System;
using ContasApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ContasApplication.Migrations
{
    [DbContext(typeof(BankContext))]
    partial class BankContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ContasApplication.Models.DespesaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DespesaFixa")
                        .HasColumnType("bit");

                    b.Property<int?>("IdParcelado")
                        .HasColumnType("int");

                    b.Property<DateTime>("MesFimParcelado")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MesReferenciaId")
                        .HasColumnType("int");

                    b.Property<string>("NomeDespesa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Parcelado")
                        .HasColumnType("bit");

                    b.Property<int>("QuantidadeParcelas")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeParcelasPagas")
                        .HasColumnType("int");

                    b.Property<double>("ValorDespesa")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("MesReferenciaId");

                    b.ToTable("Despesas");
                });

            modelBuilder.Entity("ContasApplication.Models.Mes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("MesReferencia")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeMes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("valorTotal")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Mes");
                });

            modelBuilder.Entity("ContasApplication.Models.DespesaModel", b =>
                {
                    b.HasOne("ContasApplication.Models.Mes", "MesReferencia")
                        .WithMany()
                        .HasForeignKey("MesReferenciaId");

                    b.Navigation("MesReferencia");
                });
#pragma warning restore 612, 618
        }
    }
}
