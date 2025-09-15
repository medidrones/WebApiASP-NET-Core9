using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MasterNet9.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cursos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Titulo = table.Column<string>(type: "TEXT", nullable: true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    FechaPublicacion = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "instructores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Apellidos = table.Column<string>(type: "TEXT", nullable: true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Grado = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instructores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "precios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "VARCHAR", maxLength: 250, nullable: true),
                    PrecioActual = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false),
                    PrecioPromocion = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_precios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "calificaciones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Alumno = table.Column<string>(type: "TEXT", nullable: true),
                    Puntaje = table.Column<int>(type: "INTEGER", nullable: false),
                    Comentario = table.Column<string>(type: "TEXT", nullable: true),
                    CursoId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_calificaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_calificaciones_cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "imagenes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    CursoId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imagenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_imagenes_cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cursos_instructores",
                columns: table => new
                {
                    CursoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    InstructorId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cursos_instructores", x => new { x.InstructorId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_cursos_instructores_cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cursos_instructores_instructores_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "instructores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cursos_precios",
                columns: table => new
                {
                    CursoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PrecioId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cursos_precios", x => new { x.PrecioId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_cursos_precios_cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cursos_precios_precios_PrecioId",
                        column: x => x.PrecioId,
                        principalTable: "precios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "cursos",
                columns: new[] { "Id", "Descripcion", "FechaPublicacion", "Titulo" },
                values: new object[,]
                {
                    { new Guid("0d8c8533-968a-4829-abb8-2337ea9cbbde"), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", new DateTime(2025, 9, 15, 21, 27, 0, 915, DateTimeKind.Utc).AddTicks(9304), "Practical Metal Chips" },
                    { new Guid("226fde9f-51b3-42cf-b99c-22a44ce09eee"), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", new DateTime(2025, 9, 15, 21, 27, 0, 915, DateTimeKind.Utc).AddTicks(9519), "Unbranded Frozen Pants" },
                    { new Guid("a03c3a47-2861-4fad-94cf-a4112d026883"), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", new DateTime(2025, 9, 15, 21, 27, 0, 915, DateTimeKind.Utc).AddTicks(9527), "Practical Frozen Shirt" },
                    { new Guid("ab53dd05-7558-4b26-9c6c-f382551a5ba5"), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", new DateTime(2025, 9, 15, 21, 27, 0, 915, DateTimeKind.Utc).AddTicks(9543), "Practical Granite Towels" },
                    { new Guid("c058bdb3-2fb2-4379-8daf-c25873e2248b"), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", new DateTime(2025, 9, 15, 21, 27, 0, 915, DateTimeKind.Utc).AddTicks(9550), "Rustic Soft Ball" },
                    { new Guid("c4777f59-83a3-4e9d-a9e1-42bcdbaa4d96"), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(2025, 9, 15, 21, 27, 0, 915, DateTimeKind.Utc).AddTicks(9563), "Unbranded Cotton Gloves" },
                    { new Guid("e846092c-0f15-4281-ade7-5a2b5f3bd537"), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", new DateTime(2025, 9, 15, 21, 27, 0, 915, DateTimeKind.Utc).AddTicks(9572), "Refined Concrete Pizza" },
                    { new Guid("f894ab66-b48c-4212-9ca8-71ae418dda37"), "The Football Is Good For Training And Recreational Purposes", new DateTime(2025, 9, 15, 21, 27, 0, 915, DateTimeKind.Utc).AddTicks(9508), "Handmade Cotton Pizza" },
                    { new Guid("fa74f9cd-0292-4616-b44e-2804734ba65a"), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", new DateTime(2025, 9, 15, 21, 27, 0, 915, DateTimeKind.Utc).AddTicks(9534), "Handmade Granite Fish" }
                });

            migrationBuilder.InsertData(
                table: "instructores",
                columns: new[] { "Id", "Apellidos", "Grado", "Nombre" },
                values: new object[,]
                {
                    { new Guid("026b074e-9cce-4043-93ee-7aff88337e07"), "Muller", "Lead Assurance Facilitator", "Estell" },
                    { new Guid("4aa23af3-efa7-4c06-9e04-b0c371debd30"), "Rath", "Central Accounts Manager", "Cortney" },
                    { new Guid("5a4e4f0e-7220-43f5-ad4c-0fec2efda9ae"), "Marvin", "Legacy Brand Associate", "Talon" },
                    { new Guid("607d6af1-8df0-4a68-8935-5d6fa351ed50"), "Hintz", "Lead Program Associate", "Brenden" },
                    { new Guid("66b271a9-1571-4406-8b97-35b180c292fe"), "Schoen", "Dynamic Creative Technician", "Gillian" },
                    { new Guid("740d9366-393d-4b1c-86be-639d2c572d16"), "Bednar", "Lead Tactics Assistant", "Danial" },
                    { new Guid("a5dd683c-4d30-44e8-8bac-c09fa620b216"), "Douglas", "Senior Quality Orchestrator", "Rosalinda" },
                    { new Guid("c16a56cc-77e9-4452-b2b2-e1a292a46e5d"), "Connelly", "Future Research Consultant", "Nella" },
                    { new Guid("c2e3acd2-a2d3-419d-843f-a2a3471ff9e2"), "Quigley", "Forward Implementation Executive", "Raegan" },
                    { new Guid("fdc2c6aa-e00f-4b58-94dc-6244252a33ee"), "Murphy", "Central Program Strategist", "Loyal" }
                });

            migrationBuilder.InsertData(
                table: "precios",
                columns: new[] { "Id", "Nombre", "PrecioActual", "PrecioPromocion" },
                values: new object[] { new Guid("96e21548-dbbd-466e-8b15-d30a7b19f1ac"), "Precio Regular", 10.0m, 8.0m });

            migrationBuilder.CreateIndex(
                name: "IX_calificaciones_CursoId",
                table: "calificaciones",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_cursos_instructores_CursoId",
                table: "cursos_instructores",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_cursos_precios_CursoId",
                table: "cursos_precios",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_imagenes_CursoId",
                table: "imagenes",
                column: "CursoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "calificaciones");

            migrationBuilder.DropTable(
                name: "cursos_instructores");

            migrationBuilder.DropTable(
                name: "cursos_precios");

            migrationBuilder.DropTable(
                name: "imagenes");

            migrationBuilder.DropTable(
                name: "instructores");

            migrationBuilder.DropTable(
                name: "precios");

            migrationBuilder.DropTable(
                name: "cursos");
        }
    }
}
