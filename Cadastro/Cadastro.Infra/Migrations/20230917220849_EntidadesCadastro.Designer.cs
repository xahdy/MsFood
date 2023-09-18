﻿// <auto-generated />
using System;
using Cadastro.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Cadastro.Infra.Migrations
{
    [DbContext(typeof(PostgresDbContext))]
    [Migration("20230917220849_EntidadesCadastro")]
    partial class EntidadesCadastro
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Cadastro.Domain.Models.Localizacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Deletado")
                        .HasColumnType("boolean");

                    b.Property<string>("Localidade")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Localizacao");
                });

            modelBuilder.Entity("Cadastro.Domain.Models.Prato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Deletado")
                        .HasColumnType("boolean");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Preco")
                        .HasColumnType("numeric");

                    b.Property<int>("RestauranteId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RestauranteId");

                    b.ToTable("Prato");
                });

            modelBuilder.Entity("Cadastro.Domain.Models.Restaurante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Deletado")
                        .HasColumnType("boolean");

                    b.Property<int?>("LocalizacaoId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Proprietario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LocalizacaoId");

                    b.ToTable("Restaurante");
                });

            modelBuilder.Entity("Cadastro.Domain.Models.Prato", b =>
                {
                    b.HasOne("Cadastro.Domain.Models.Restaurante", "Restaurante")
                        .WithMany("ListaPratos")
                        .HasForeignKey("RestauranteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurante");
                });

            modelBuilder.Entity("Cadastro.Domain.Models.Restaurante", b =>
                {
                    b.HasOne("Cadastro.Domain.Models.Localizacao", "Localizacao")
                        .WithMany()
                        .HasForeignKey("LocalizacaoId");

                    b.Navigation("Localizacao");
                });

            modelBuilder.Entity("Cadastro.Domain.Models.Restaurante", b =>
                {
                    b.Navigation("ListaPratos");
                });
#pragma warning restore 612, 618
        }
    }
}