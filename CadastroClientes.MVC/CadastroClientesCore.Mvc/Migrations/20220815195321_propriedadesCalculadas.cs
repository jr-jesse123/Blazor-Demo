using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroClientes.MVC.Migrations
{
    public partial class propriedadesCalculadas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Idade",
                table: "clientes");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DataNascimento",
                table: "clientes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "clientes");

            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "clientes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
