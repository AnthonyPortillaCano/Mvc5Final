using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ExamenParcialTotal.Data.Migrations
{
    public partial class script2017parcial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Solicitudes",
                columns: table => new
                {
                    SolicitudID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Motivo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitudes", x => x.SolicitudID);
                });

            migrationBuilder.CreateTable(
                name: "DetalleSolicitudes",
                columns: table => new
                {
                    DetalleSolicitudID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true),
                    Duracion = table.Column<int>(nullable: false),
                    FechaViaje = table.Column<DateTime>(nullable: false),
                    GastoHotel = table.Column<decimal>(nullable: false),
                    GastoMovilidad = table.Column<decimal>(nullable: false),
                    MontoGastar = table.Column<decimal>(nullable: false),
                    MotivoViaje = table.Column<string>(nullable: true),
                    NombreSolicitante = table.Column<string>(nullable: true),
                    SolicitudID = table.Column<int>(nullable: true),
                    SustentoAprobacion = table.Column<string>(nullable: true),
                    estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleSolicitudes", x => x.DetalleSolicitudID);
                    table.ForeignKey(
                        name: "FK_DetalleSolicitudes_Solicitudes_SolicitudID",
                        column: x => x.SolicitudID,
                        principalTable: "Solicitudes",
                        principalColumn: "SolicitudID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DNI",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetalleSolicitudes_SolicitudID",
                table: "DetalleSolicitudes",
                column: "SolicitudID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DNI",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DetalleSolicitudes");

            migrationBuilder.DropTable(
                name: "Solicitudes");
        }
    }
}
