using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamenParcialTotal.Data.Migrations
{
    public partial class scriptnuevo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<char>(
                name: "estado",
                table: "DetalleSolicitudes",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "estado",
                table: "DetalleSolicitudes",
                nullable: false);
        }
    }
}
