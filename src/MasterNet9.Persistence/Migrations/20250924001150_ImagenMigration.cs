using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MasterNet9.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ImagenMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    NombreCompleto = table.Column<string>(type: "TEXT", nullable: true),
                    Carrera = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    CursoId = table.Column<Guid>(type: "TEXT", nullable: true),
                    PublicId = table.Column<string>(type: "TEXT", nullable: true)
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "13fb926c-5b58-492e-a488-56a6d804b239", null, "ADMIN", "ADMIN" },
                    { "fe66f542-08b5-4fee-8f82-7d563dac2f16", null, "CLIENT", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "cursos",
                columns: new[] { "Id", "Descripcion", "FechaPublicacion", "Titulo" },
                values: new object[,]
                {
                    { new Guid("048c3313-e232-41d6-928f-41762967d651"), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(2025, 9, 24, 0, 11, 48, 711, DateTimeKind.Utc).AddTicks(3190), "Practical Cotton Shoes" },
                    { new Guid("131445d7-fbd6-47a7-9f26-40be8c250fce"), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", new DateTime(2025, 9, 24, 0, 11, 48, 711, DateTimeKind.Utc).AddTicks(3227), "Ergonomic Frozen Sausages" },
                    { new Guid("1621b994-b775-4f7e-8922-17383813bd89"), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", new DateTime(2025, 9, 24, 0, 11, 48, 711, DateTimeKind.Utc).AddTicks(3233), "Intelligent Steel Shoes" },
                    { new Guid("4cc1fe48-d321-4f03-998d-bc825f37d2f5"), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", new DateTime(2025, 9, 24, 0, 11, 48, 711, DateTimeKind.Utc).AddTicks(3196), "Sleek Wooden Shoes" },
                    { new Guid("604aef1c-b316-4c66-b50c-9148807f3d5a"), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", new DateTime(2025, 9, 24, 0, 11, 48, 711, DateTimeKind.Utc).AddTicks(3180), "Small Rubber Bacon" },
                    { new Guid("798f78c1-f755-41d7-8ced-6896d5ddc5f9"), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", new DateTime(2025, 9, 24, 0, 11, 48, 711, DateTimeKind.Utc).AddTicks(3158), "Gorgeous Cotton Fish" },
                    { new Guid("90745dde-7bd5-4def-9af2-5f8574fc311b"), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", new DateTime(2025, 9, 24, 0, 11, 48, 711, DateTimeKind.Utc).AddTicks(3206), "Awesome Granite Shirt" },
                    { new Guid("b61eedaf-6767-41dc-b540-46ad1415ab75"), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(2025, 9, 24, 0, 11, 48, 711, DateTimeKind.Utc).AddTicks(3213), "Ergonomic Concrete Car" },
                    { new Guid("f5a5e181-45f7-4ba0-9558-7ba36eea2245"), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", new DateTime(2025, 9, 24, 0, 11, 48, 711, DateTimeKind.Utc).AddTicks(2950), "Handmade Plastic Mouse" }
                });

            migrationBuilder.InsertData(
                table: "instructores",
                columns: new[] { "Id", "Apellidos", "Grado", "Nombre" },
                values: new object[,]
                {
                    { new Guid("0c7c918e-97eb-4750-8977-fcd4e72ef20f"), "Jakubowski", "Direct Tactics Strategist", "Magnus" },
                    { new Guid("2e804702-a401-49e7-8ba4-0727f7dc4b17"), "Bailey", "Regional Factors Agent", "Stanley" },
                    { new Guid("48548e21-f2b7-49e0-8162-c2b8c9a473b9"), "Kulas", "Corporate Assurance Representative", "Kim" },
                    { new Guid("4906c791-d427-4b5e-9814-f2ebdb381c8e"), "Jones", "International Division Designer", "Laisha" },
                    { new Guid("75620d2e-da5a-4ce2-ac05-fdf38204de73"), "Deckow", "Chief Research Orchestrator", "Deborah" },
                    { new Guid("79fc6c8c-c22a-49a5-8b53-572acac3d63c"), "Hane", "Principal Applications Developer", "Mark" },
                    { new Guid("9392efdb-2e6f-4c64-89c9-fc44e97871b1"), "Harris", "Internal Markets Liaison", "Assunta" },
                    { new Guid("b8d5f84a-c046-4316-bd78-76b1f6fec522"), "Pouros", "Senior Interactions Supervisor", "Celia" },
                    { new Guid("d5af3420-17b2-4e12-ac2e-70be7cf7176a"), "Rutherford", "Investor Brand Producer", "Edwina" },
                    { new Guid("fd4a67b0-c04f-4696-bd35-4518d7308c64"), "Gibson", "Investor Tactics Orchestrator", "Isobel" }
                });

            migrationBuilder.InsertData(
                table: "precios",
                columns: new[] { "Id", "Nombre", "PrecioActual", "PrecioPromocion" },
                values: new object[] { new Guid("d7597e3b-f2b7-419e-8e9b-d056fb2e832f"), "Precio Regular", 10.0m, 8.0m });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "POLICIES", "CURSO_READ", "13fb926c-5b58-492e-a488-56a6d804b239" },
                    { 2, "POLICIES", "CURSO_UPADATE", "13fb926c-5b58-492e-a488-56a6d804b239" },
                    { 3, "POLICIES", "CURSO_WRITE", "13fb926c-5b58-492e-a488-56a6d804b239" },
                    { 4, "POLICIES", "CURSO_DELETE", "13fb926c-5b58-492e-a488-56a6d804b239" },
                    { 5, "POLICIES", "INSTRUCTOR_CREATE", "13fb926c-5b58-492e-a488-56a6d804b239" },
                    { 6, "POLICIES", "INSTRUCTOR_READ", "13fb926c-5b58-492e-a488-56a6d804b239" },
                    { 7, "POLICIES", "INSTRUCTOR_UPDATE", "13fb926c-5b58-492e-a488-56a6d804b239" },
                    { 8, "POLICIES", "COMENTARIO_READ", "13fb926c-5b58-492e-a488-56a6d804b239" },
                    { 9, "POLICIES", "COMENTARIO_DELETE", "13fb926c-5b58-492e-a488-56a6d804b239" },
                    { 10, "POLICIES", "COMENTARIO_CREATE", "13fb926c-5b58-492e-a488-56a6d804b239" },
                    { 11, "POLICIES", "CURSO_READ", "fe66f542-08b5-4fee-8f82-7d563dac2f16" },
                    { 12, "POLICIES", "INSTRUCTOR_READ", "fe66f542-08b5-4fee-8f82-7d563dac2f16" },
                    { 13, "POLICIES", "COMENTARIO_READ", "fe66f542-08b5-4fee-8f82-7d563dac2f16" },
                    { 14, "POLICIES", "COMENTARIO_CREATE", "fe66f542-08b5-4fee-8f82-7d563dac2f16" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "calificaciones");

            migrationBuilder.DropTable(
                name: "cursos_instructores");

            migrationBuilder.DropTable(
                name: "cursos_precios");

            migrationBuilder.DropTable(
                name: "imagenes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "instructores");

            migrationBuilder.DropTable(
                name: "precios");

            migrationBuilder.DropTable(
                name: "cursos");
        }
    }
}
