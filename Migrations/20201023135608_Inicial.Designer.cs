﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistroAgenda.DAL;

namespace RegistroAgenda.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20201023135608_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("RegistroAgenda.Entidades.Contactos", b =>
                {
                    b.Property<int>("ContactoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("TEXT");

                    b.Property<string>("NickName")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreCompleto")
                        .HasColumnType("TEXT");

                    b.Property<long>("Telefono")
                        .HasColumnType("INTEGER");

                    b.HasKey("ContactoId");

                    b.ToTable("Contactos");
                });

            modelBuilder.Entity("RegistroAgenda.Entidades.Eventos", b =>
                {
                    b.Property<int>("EventoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContactoId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("TEXT");

                    b.Property<string>("Lugar")
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoEvento")
                        .HasColumnType("TEXT");

                    b.HasKey("EventoId");

                    b.HasIndex("ContactoId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("RegistroAgenda.Entidades.Eventos", b =>
                {
                    b.HasOne("RegistroAgenda.Entidades.Contactos", "contactos")
                        .WithMany()
                        .HasForeignKey("ContactoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
