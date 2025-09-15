using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MasterNet9.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MigracionSeguridad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("0d8c8533-968a-4829-abb8-2337ea9cbbde"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("226fde9f-51b3-42cf-b99c-22a44ce09eee"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("a03c3a47-2861-4fad-94cf-a4112d026883"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("ab53dd05-7558-4b26-9c6c-f382551a5ba5"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("c058bdb3-2fb2-4379-8daf-c25873e2248b"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("c4777f59-83a3-4e9d-a9e1-42bcdbaa4d96"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("e846092c-0f15-4281-ade7-5a2b5f3bd537"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("f894ab66-b48c-4212-9ca8-71ae418dda37"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("fa74f9cd-0292-4616-b44e-2804734ba65a"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("026b074e-9cce-4043-93ee-7aff88337e07"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("4aa23af3-efa7-4c06-9e04-b0c371debd30"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("5a4e4f0e-7220-43f5-ad4c-0fec2efda9ae"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("607d6af1-8df0-4a68-8935-5d6fa351ed50"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("66b271a9-1571-4406-8b97-35b180c292fe"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("740d9366-393d-4b1c-86be-639d2c572d16"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("a5dd683c-4d30-44e8-8bac-c09fa620b216"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("c16a56cc-77e9-4452-b2b2-e1a292a46e5d"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("c2e3acd2-a2d3-419d-843f-a2a3471ff9e2"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("fdc2c6aa-e00f-4b58-94dc-6244252a33ee"));

            migrationBuilder.DeleteData(
                table: "precios",
                keyColumn: "Id",
                keyValue: new Guid("96e21548-dbbd-466e-8b15-d30a7b19f1ac"));

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3bd7bbf8-13a3-4027-8556-38cc38560bc7", null, "ADMIN", "ADMIN" },
                    { "60fa6c73-7b73-426d-95cb-e8de15be973b", null, "CLIENT", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "cursos",
                columns: new[] { "Id", "Descripcion", "FechaPublicacion", "Titulo" },
                values: new object[,]
                {
                    { new Guid("00c407b8-7d90-44fd-a6ba-1d824c97f839"), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", new DateTime(2025, 9, 15, 23, 14, 40, 625, DateTimeKind.Utc).AddTicks(9494), "Rustic Plastic Mouse" },
                    { new Guid("47ec397f-f000-4abb-8246-26cf15aff5d0"), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(2025, 9, 15, 23, 14, 40, 625, DateTimeKind.Utc).AddTicks(9532), "Intelligent Rubber Hat" },
                    { new Guid("4b3321af-1e87-46e2-8c38-a3a7049a194e"), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", new DateTime(2025, 9, 15, 23, 14, 40, 625, DateTimeKind.Utc).AddTicks(9286), "Handmade Fresh Chair" },
                    { new Guid("51b71e7f-81ef-4328-8d4b-bfe6a7364a32"), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(2025, 9, 15, 23, 14, 40, 625, DateTimeKind.Utc).AddTicks(9513), "Sleek Wooden Soap" },
                    { new Guid("62dd5fcb-0156-4df8-982f-a780ea97500f"), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(2025, 9, 15, 23, 14, 40, 625, DateTimeKind.Utc).AddTicks(9550), "Handmade Steel Mouse" },
                    { new Guid("6ce2077d-7e84-438a-aa5f-89ce0357e385"), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", new DateTime(2025, 9, 15, 23, 14, 40, 625, DateTimeKind.Utc).AddTicks(9568), "Practical Metal Chair" },
                    { new Guid("8c071c4f-41b1-4ef9-8790-74dc1b3e10b4"), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", new DateTime(2025, 9, 15, 23, 14, 40, 625, DateTimeKind.Utc).AddTicks(9558), "Handmade Soft Bike" },
                    { new Guid("afb60a53-2449-4ab8-a500-225a0d526b67"), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", new DateTime(2025, 9, 15, 23, 14, 40, 625, DateTimeKind.Utc).AddTicks(9505), "Handcrafted Wooden Pizza" },
                    { new Guid("edd1d613-8d19-4ef2-9d64-f62ef4cbeac0"), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", new DateTime(2025, 9, 15, 23, 14, 40, 625, DateTimeKind.Utc).AddTicks(9522), "Sleek Wooden Gloves" }
                });

            migrationBuilder.InsertData(
                table: "instructores",
                columns: new[] { "Id", "Apellidos", "Grado", "Nombre" },
                values: new object[,]
                {
                    { new Guid("01062f66-f991-49c1-8862-105075594067"), "McClure", "Chief Identity Associate", "Alysson" },
                    { new Guid("0db62a26-e381-414a-8532-9435091eb430"), "Russel", "Lead Usability Assistant", "Marcella" },
                    { new Guid("103360ff-9c1e-4636-b372-552cfe6a16a4"), "Medhurst", "Future Accounts Engineer", "Claude" },
                    { new Guid("30bf00e7-5796-459d-8bb4-0aa6b411bc5e"), "Blanda", "Regional Response Associate", "Jana" },
                    { new Guid("3f276528-153f-4922-9e51-3446067359a5"), "Koepp", "Principal Optimization Facilitator", "Hazel" },
                    { new Guid("677dcb46-10e6-408f-8b64-a831fc698f34"), "Bashirian", "Human Interactions Executive", "Janet" },
                    { new Guid("9b8b4ef3-6f84-46bb-a04e-60e2fe4b34e9"), "Mayert", "Regional Infrastructure Engineer", "Jabari" },
                    { new Guid("a6f3adaf-48b7-4b4e-80ce-43dc48645fda"), "Konopelski", "Legacy Intranet Representative", "Dejah" },
                    { new Guid("dac98769-49e0-445d-83b7-36c98edd3f1f"), "Corwin", "Corporate Solutions Administrator", "Solon" },
                    { new Guid("f130e4ab-28b6-4c90-9a1d-76dd97600c6f"), "Homenick", "Investor Markets Coordinator", "Osborne" }
                });

            migrationBuilder.InsertData(
                table: "precios",
                columns: new[] { "Id", "Nombre", "PrecioActual", "PrecioPromocion" },
                values: new object[] { new Guid("69912527-d2d1-4586-9a1e-dbad15e3fc3d"), "Precio Regular", 10.0m, 8.0m });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "POLICIES", "CURSO_READ", "3bd7bbf8-13a3-4027-8556-38cc38560bc7" },
                    { 2, "POLICIES", "CURSO_UPADATE", "3bd7bbf8-13a3-4027-8556-38cc38560bc7" },
                    { 3, "POLICIES", "CURSO_WRITE", "3bd7bbf8-13a3-4027-8556-38cc38560bc7" },
                    { 4, "POLICIES", "CURSO_DELETE", "3bd7bbf8-13a3-4027-8556-38cc38560bc7" },
                    { 5, "POLICIES", "INSTRUCTOR_CREATE", "3bd7bbf8-13a3-4027-8556-38cc38560bc7" },
                    { 6, "POLICIES", "INSTRUCTOR_READ", "3bd7bbf8-13a3-4027-8556-38cc38560bc7" },
                    { 7, "POLICIES", "INSTRUCTOR_UPDATE", "3bd7bbf8-13a3-4027-8556-38cc38560bc7" },
                    { 8, "POLICIES", "COMENTARIO_READ", "3bd7bbf8-13a3-4027-8556-38cc38560bc7" },
                    { 9, "POLICIES", "COMENTARIO_DELETE", "3bd7bbf8-13a3-4027-8556-38cc38560bc7" },
                    { 10, "POLICIES", "COMENTARIO_CREATE", "3bd7bbf8-13a3-4027-8556-38cc38560bc7" },
                    { 11, "POLICIES", "CURSO_READ", "60fa6c73-7b73-426d-95cb-e8de15be973b" },
                    { 12, "POLICIES", "INSTRUCTOR_READ", "60fa6c73-7b73-426d-95cb-e8de15be973b" },
                    { 13, "POLICIES", "COMENTARIO_READ", "60fa6c73-7b73-426d-95cb-e8de15be973b" },
                    { 14, "POLICIES", "COMENTARIO_CREATE", "60fa6c73-7b73-426d-95cb-e8de15be973b" }
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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("00c407b8-7d90-44fd-a6ba-1d824c97f839"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("47ec397f-f000-4abb-8246-26cf15aff5d0"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("4b3321af-1e87-46e2-8c38-a3a7049a194e"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("51b71e7f-81ef-4328-8d4b-bfe6a7364a32"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("62dd5fcb-0156-4df8-982f-a780ea97500f"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("6ce2077d-7e84-438a-aa5f-89ce0357e385"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("8c071c4f-41b1-4ef9-8790-74dc1b3e10b4"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("afb60a53-2449-4ab8-a500-225a0d526b67"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("edd1d613-8d19-4ef2-9d64-f62ef4cbeac0"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("01062f66-f991-49c1-8862-105075594067"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("0db62a26-e381-414a-8532-9435091eb430"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("103360ff-9c1e-4636-b372-552cfe6a16a4"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("30bf00e7-5796-459d-8bb4-0aa6b411bc5e"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("3f276528-153f-4922-9e51-3446067359a5"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("677dcb46-10e6-408f-8b64-a831fc698f34"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("9b8b4ef3-6f84-46bb-a04e-60e2fe4b34e9"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("a6f3adaf-48b7-4b4e-80ce-43dc48645fda"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("dac98769-49e0-445d-83b7-36c98edd3f1f"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("f130e4ab-28b6-4c90-9a1d-76dd97600c6f"));

            migrationBuilder.DeleteData(
                table: "precios",
                keyColumn: "Id",
                keyValue: new Guid("69912527-d2d1-4586-9a1e-dbad15e3fc3d"));

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
        }
    }
}
