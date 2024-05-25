﻿// <auto-generated />
using System;
using Cesla.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cesla.Data.Migrations
{
    [DbContext(typeof(CeslaContext))]
    [Migration("20240525174616_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Cesla.Domain.Entities.Cargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Salario")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("cargo_tb", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataCadastro = new DateTime(2024, 5, 25, 14, 46, 15, 629, DateTimeKind.Local).AddTicks(626),
                            DepartamentoId = 1,
                            Nome = "Gerente Administrativo",
                            Salario = 12000.00m
                        },
                        new
                        {
                            Id = 2,
                            DataCadastro = new DateTime(2024, 5, 25, 14, 46, 15, 629, DateTimeKind.Local).AddTicks(673),
                            DepartamentoId = 1,
                            Nome = "Assistente Administrativo",
                            Salario = 3000.00m
                        },
                        new
                        {
                            Id = 3,
                            DataCadastro = new DateTime(2024, 5, 25, 14, 46, 15, 629, DateTimeKind.Local).AddTicks(730),
                            DepartamentoId = 1,
                            Nome = "Secret�ria Executiva",
                            Salario = 5000.00m
                        },
                        new
                        {
                            Id = 4,
                            DataCadastro = new DateTime(2024, 5, 25, 14, 46, 15, 629, DateTimeKind.Local).AddTicks(744),
                            DepartamentoId = 1,
                            Nome = "Analista Administrativo",
                            Salario = 6000.00m
                        },
                        new
                        {
                            Id = 5,
                            DataCadastro = new DateTime(2024, 5, 25, 14, 46, 15, 629, DateTimeKind.Local).AddTicks(758),
                            DepartamentoId = 1,
                            Nome = "Coordenador de Recursos Humanos",
                            Salario = 7000.00m
                        },
                        new
                        {
                            Id = 6,
                            DataCadastro = new DateTime(2024, 5, 25, 14, 46, 15, 629, DateTimeKind.Local).AddTicks(772),
                            DepartamentoId = 1,
                            Nome = "Recepcionista",
                            Salario = 2500.00m
                        },
                        new
                        {
                            Id = 7,
                            DataCadastro = new DateTime(2024, 5, 25, 14, 46, 15, 629, DateTimeKind.Local).AddTicks(786),
                            DepartamentoId = 1,
                            Nome = "Controlador de Documentos",
                            Salario = 4000.00m
                        },
                        new
                        {
                            Id = 8,
                            DataCadastro = new DateTime(2024, 5, 25, 14, 46, 15, 629, DateTimeKind.Local).AddTicks(803),
                            DepartamentoId = 1,
                            Nome = "Supervisor de Escrit�rio",
                            Salario = 5500.00m
                        },
                        new
                        {
                            Id = 9,
                            DataCadastro = new DateTime(2024, 5, 25, 14, 46, 15, 629, DateTimeKind.Local).AddTicks(818),
                            DepartamentoId = 1,
                            Nome = "Analista de Compras",
                            Salario = 6500.00m
                        },
                        new
                        {
                            Id = 10,
                            DataCadastro = new DateTime(2024, 5, 25, 14, 46, 15, 629, DateTimeKind.Local).AddTicks(831),
                            DepartamentoId = 1,
                            Nome = "Gerente de Facilidades",
                            Salario = 8000.00m
                        },
                        new
                        {
                            Id = 11,
                            DataCadastro = new DateTime(2024, 5, 25, 14, 46, 15, 629, DateTimeKind.Local).AddTicks(847),
                            DepartamentoId = 1,
                            Nome = "Analista Financeiro",
                            Salario = 7500.00m
                        },
                        new
                        {
                            Id = 12,
                            DataCadastro = new DateTime(2024, 5, 25, 14, 46, 15, 629, DateTimeKind.Local).AddTicks(860),
                            DepartamentoId = 1,
                            Nome = "Assistente de Contabilidade",
                            Salario = 3500.00m
                        },
                        new
                        {
                            Id = 13,
                            DataCadastro = new DateTime(2024, 5, 25, 14, 46, 15, 629, DateTimeKind.Local).AddTicks(875),
                            DepartamentoId = 1,
                            Nome = "Analista de Planejamento",
                            Salario = 7000.00m
                        },
                        new
                        {
                            Id = 14,
                            DataCadastro = new DateTime(2024, 5, 25, 14, 46, 15, 629, DateTimeKind.Local).AddTicks(888),
                            DepartamentoId = 1,
                            Nome = "Coordenador de Eventos",
                            Salario = 4500.00m
                        },
                        new
                        {
                            Id = 15,
                            DataCadastro = new DateTime(2024, 5, 25, 14, 46, 15, 629, DateTimeKind.Local).AddTicks(901),
                            DepartamentoId = 1,
                            Nome = "Analista de Projetos",
                            Salario = 6500.00m
                        },
                        new
                        {
                            Id = 16,
                            DataCadastro = new DateTime(2024, 5, 25, 14, 46, 15, 629, DateTimeKind.Local).AddTicks(914),
                            DepartamentoId = 1,
                            Nome = "Especialista em Conformidade",
                            Salario = 7000.00m
                        },
                        new
                        {
                            Id = 17,
                            DataCadastro = new DateTime(2024, 5, 25, 14, 46, 15, 629, DateTimeKind.Local).AddTicks(928),
                            DepartamentoId = 1,
                            Nome = "Gerente de Comunica��es Internas",
                            Salario = 7500.00m
                        },
                        new
                        {
                            Id = 18,
                            DataCadastro = new DateTime(2024, 5, 25, 14, 46, 15, 629, DateTimeKind.Local).AddTicks(943),
                            DepartamentoId = 1,
                            Nome = "Analista de Suprimentos",
                            Salario = 6000.00m
                        },
                        new
                        {
                            Id = 19,
                            DataCadastro = new DateTime(2024, 5, 25, 14, 46, 15, 629, DateTimeKind.Local).AddTicks(957),
                            DepartamentoId = 1,
                            Nome = "Assistente de Log�stica",
                            Salario = 3500.00m
                        },
                        new
                        {
                            Id = 20,
                            DataCadastro = new DateTime(2024, 5, 25, 14, 46, 15, 629, DateTimeKind.Local).AddTicks(971),
                            DepartamentoId = 1,
                            Nome = "Administrador de Contratos",
                            Salario = 6500.00m
                        });
                });

            modelBuilder.Entity("Cesla.Domain.Entities.Colaborador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("CargoId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CargoId");

                    b.ToTable("colaborador_tb", (string)null);
                });

            modelBuilder.Entity("Cesla.Domain.Entities.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("departamento_tb", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataCadastro = new DateTime(2024, 5, 25, 14, 46, 15, 626, DateTimeKind.Local).AddTicks(8778),
                            EmpresaId = 1,
                            Nome = "Administrativo"
                        });
                });

            modelBuilder.Entity("Cesla.Domain.Entities.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.ToTable("empresa_tb", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataCadastro = new DateTime(2024, 5, 25, 14, 46, 15, 626, DateTimeKind.Local).AddTicks(8749),
                            EnderecoId = 1,
                            Nome = "Cesla",
                            Telefone = "1101234567"
                        });
                });

            modelBuilder.Entity("Cesla.Domain.Entities.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("varchar(8)")
                        .HasColumnName("CEP");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Cidade");

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Estado");

                    b.Property<int>("Numero")
                        .HasColumnType("int")
                        .HasColumnName("Numero");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Pais");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Rua");

                    b.HasKey("Id");

                    b.ToTable("endereco_tb", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CEP = "21345678",
                            Cidade = "Rio de Janeiro",
                            DataCadastro = new DateTime(2024, 5, 25, 14, 46, 15, 626, DateTimeKind.Local).AddTicks(8670),
                            Estado = "RJ",
                            Numero = 20,
                            Pais = "Brasil",
                            Rua = "Rua Teste"
                        });
                });

            modelBuilder.Entity("Cesla.Domain.Entities.Cargo", b =>
                {
                    b.HasOne("Cesla.Domain.Entities.Departamento", "Departamento")
                        .WithMany("Cargos")
                        .HasForeignKey("DepartamentoId")
                        .IsRequired();

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("Cesla.Domain.Entities.Colaborador", b =>
                {
                    b.HasOne("Cesla.Domain.Entities.Cargo", "Cargo")
                        .WithMany("Colaboradores")
                        .HasForeignKey("CargoId")
                        .IsRequired();

                    b.Navigation("Cargo");
                });

            modelBuilder.Entity("Cesla.Domain.Entities.Departamento", b =>
                {
                    b.HasOne("Cesla.Domain.Entities.Empresa", "Empresa")
                        .WithMany("Departamentos")
                        .HasForeignKey("EmpresaId")
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Cesla.Domain.Entities.Empresa", b =>
                {
                    b.HasOne("Cesla.Domain.Entities.Endereco", "Endereco")
                        .WithOne()
                        .HasForeignKey("Cesla.Domain.Entities.Empresa", "EnderecoId")
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Cesla.Domain.Entities.Cargo", b =>
                {
                    b.Navigation("Colaboradores");
                });

            modelBuilder.Entity("Cesla.Domain.Entities.Departamento", b =>
                {
                    b.Navigation("Cargos");
                });

            modelBuilder.Entity("Cesla.Domain.Entities.Empresa", b =>
                {
                    b.Navigation("Departamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
