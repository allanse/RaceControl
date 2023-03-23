﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RaceControl.Infraestrutura.Migrations
{
    public partial class InicializarBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competidores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(maxLength: 150, nullable: false),
                    Sexo = table.Column<int>(nullable: false),
                    TemperaturaMediaCorpo = table.Column<decimal>(nullable: false),
                    Peso = table.Column<decimal>(nullable: false),
                    Altura = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competidores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PistaCorrida",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PistaCorrida", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoCorrida",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompetidorId = table.Column<int>(nullable: false),
                    PistaCorridaId = table.Column<int>(nullable: false),
                    DataCorrida = table.Column<DateTime>(nullable: false),
                    TempoGasto = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoCorrida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoCorrida_Competidores_CompetidorId",
                        column: x => x.CompetidorId,
                        principalTable: "Competidores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoricoCorrida_PistaCorrida_PistaCorridaId",
                        column: x => x.PistaCorridaId,
                        principalTable: "PistaCorrida",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoCorrida_CompetidorId",
                table: "HistoricoCorrida",
                column: "CompetidorId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoCorrida_PistaCorridaId",
                table: "HistoricoCorrida",
                column: "PistaCorridaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoCorrida");

            migrationBuilder.DropTable(
                name: "Competidores");

            migrationBuilder.DropTable(
                name: "PistaCorrida");
        }
    }
}
