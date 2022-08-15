﻿// <auto-generated />
using System;
using CadastroClientesCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CadastroClientes.MVC.Migrations
{
    [DbContext(typeof(CadastroClientesContext))]
    partial class CadastroClientesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.8");

            modelBuilder.Entity("CadastroClientes.MVC.Models.ModeloCliente", b =>
                {
                    b.Property<string>("CPF")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CPF");

                    b.ToTable("clientes");
                });
#pragma warning restore 612, 618
        }
    }
}