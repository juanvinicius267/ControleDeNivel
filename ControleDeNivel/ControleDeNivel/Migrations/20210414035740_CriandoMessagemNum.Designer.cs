﻿// <auto-generated />
using System;
using ControleDeNivel.Data.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControleDeNivel.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210414035740_CriandoMessagemNum")]
    partial class CriandoMessagemNum
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ControleDeNivel.Models.DeviceInfo", b =>
                {
                    b.Property<int>("IdDeviceInfo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.Property<string>("GuildCode");

                    b.Property<string>("IpAdress");

                    b.Property<string>("Name");

                    b.HasKey("IdDeviceInfo");

                    b.ToTable("DeviceInfos");
                });

            modelBuilder.Entity("ControleDeNivel.Models.LogFalha", b =>
                {
                    b.Property<int>("IdLogFalhas")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Codigo");

                    b.Property<string>("Descricao");

                    b.Property<DateTime>("RecordDate");

                    b.HasKey("IdLogFalhas");

                    b.ToTable("LogFalhas");
                });

            modelBuilder.Entity("ControleDeNivel.Models.Mensagem", b =>
                {
                    b.Property<int>("IdMensagem")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descrição");

                    b.Property<int>("Tipo");

                    b.HasKey("IdMensagem");

                    b.ToTable("Mensagens");
                });

            modelBuilder.Entity("ControleDeNivel.Models.Sinal", b =>
                {
                    b.Property<int>("IdSinal")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataDeAtualizacao");

                    b.Property<bool>("I00");

                    b.Property<bool>("I01");

                    b.Property<bool>("I02");

                    b.Property<bool>("I03");

                    b.Property<bool>("I04");

                    b.Property<bool>("I05");

                    b.Property<bool>("I06");

                    b.Property<bool>("I07");

                    b.Property<int>("IdDeviceInfo");

                    b.Property<int>("MessagemNum");

                    b.Property<bool>("Q00");

                    b.Property<bool>("Q01");

                    b.Property<bool>("Q02");

                    b.Property<bool>("Q03");

                    b.Property<bool>("Q04");

                    b.Property<bool>("Q05");

                    b.Property<bool>("Q06");

                    b.Property<bool>("Q07");

                    b.HasKey("IdSinal");

                    b.HasIndex("IdDeviceInfo");

                    b.ToTable("Sinais");
                });

            modelBuilder.Entity("ControleDeNivel.Models.Sinal", b =>
                {
                    b.HasOne("ControleDeNivel.Models.DeviceInfo", "DeviceInfo")
                        .WithMany()
                        .HasForeignKey("IdDeviceInfo")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
