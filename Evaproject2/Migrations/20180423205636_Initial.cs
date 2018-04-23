using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Evaproject2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Criterio",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Calificacion = table.Column<int>(nullable: false),
                    FC = table.Column<DateTime>(nullable: false),
                    FM = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criterio", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Apellido = table.Column<string>(nullable: true),
                    CampoEstudios = table.Column<string>(nullable: true),
                    Celular = table.Column<string>(nullable: true),
                    Ciudad = table.Column<string>(nullable: true),
                    CodigoPostal = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Domicilio = table.Column<string>(nullable: true),
                    FC = table.Column<DateTime>(nullable: false),
                    FM = table.Column<DateTime>(nullable: false),
                    FNacimiento = table.Column<DateTime>(nullable: false),
                    NivelEstudios = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Pwd = table.Column<string>(nullable: true),
                    TipoUsuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Aspecto",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Calificacion = table.Column<double>(nullable: false),
                    CriterioID = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    FC = table.Column<DateTime>(nullable: false),
                    FM = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aspecto", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Aspecto_Criterio_CriterioID",
                        column: x => x.CriterioID,
                        principalTable: "Criterio",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Convocatoria",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CriterioID = table.Column<int>(nullable: false),
                    FC = table.Column<DateTime>(nullable: false),
                    FEnvio = table.Column<DateTime>(nullable: false),
                    FEvaluacion = table.Column<DateTime>(nullable: false),
                    FM = table.Column<DateTime>(nullable: false),
                    FRegistro = table.Column<DateTime>(nullable: false),
                    FResultados = table.Column<DateTime>(nullable: false),
                    NoEvaluadores = table.Column<int>(nullable: false),
                    NoParticipantes = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    RutaDescripcion = table.Column<string>(nullable: true),
                    RutaResultados = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convocatoria", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Convocatoria_Criterio_CriterioID",
                        column: x => x.CriterioID,
                        principalTable: "Criterio",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscripcion",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConvocatoriaID = table.Column<int>(nullable: false),
                    FC = table.Column<DateTime>(nullable: false),
                    FM = table.Column<DateTime>(nullable: false),
                    ParticipanteID = table.Column<int>(nullable: false),
                    PdfProyecto = table.Column<string>(nullable: true),
                    TipoInscripcion = table.Column<int>(nullable: false),
                    UsuarioID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripcion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Inscripcion_Convocatoria_ConvocatoriaID",
                        column: x => x.ConvocatoriaID,
                        principalTable: "Convocatoria",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripcion_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Evaluacion",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CriterioID = table.Column<int>(nullable: false),
                    EvaluadorID = table.Column<int>(nullable: false),
                    FC = table.Column<DateTime>(nullable: false),
                    FM = table.Column<DateTime>(nullable: false),
                    InscripcionID = table.Column<int>(nullable: true),
                    UsuarioID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluacion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Evaluacion_Criterio_CriterioID",
                        column: x => x.CriterioID,
                        principalTable: "Criterio",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluacion_Inscripcion_InscripcionID",
                        column: x => x.InscripcionID,
                        principalTable: "Inscripcion",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Evaluacion_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aspecto_CriterioID",
                table: "Aspecto",
                column: "CriterioID");

            migrationBuilder.CreateIndex(
                name: "IX_Convocatoria_CriterioID",
                table: "Convocatoria",
                column: "CriterioID");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluacion_CriterioID",
                table: "Evaluacion",
                column: "CriterioID");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluacion_InscripcionID",
                table: "Evaluacion",
                column: "InscripcionID");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluacion_UsuarioID",
                table: "Evaluacion",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_ConvocatoriaID",
                table: "Inscripcion",
                column: "ConvocatoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_UsuarioID",
                table: "Inscripcion",
                column: "UsuarioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aspecto");

            migrationBuilder.DropTable(
                name: "Evaluacion");

            migrationBuilder.DropTable(
                name: "Inscripcion");

            migrationBuilder.DropTable(
                name: "Convocatoria");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Criterio");
        }
    }
}
