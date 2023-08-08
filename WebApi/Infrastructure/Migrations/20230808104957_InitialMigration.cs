using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaterialId = table.Column<int>(type: "integer", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sheets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Length = table.Column<double>(type: "double precision", nullable: false),
                    Width = table.Column<double>(type: "double precision", nullable: false),
                    JobId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sheets_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Circles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    xPosition = table.Column<double>(type: "double precision", nullable: false),
                    yPosition = table.Column<double>(type: "double precision", nullable: false),
                    Radius = table.Column<double>(type: "double precision", nullable: false),
                    SheetId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Circles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Circles_Sheets_SheetId",
                        column: x => x.SheetId,
                        principalTable: "Sheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PolyLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    xPosition = table.Column<double>(type: "double precision", nullable: false),
                    yPosition = table.Column<double>(type: "double precision", nullable: false),
                    Bulge = table.Column<double>(type: "double precision", nullable: false),
                    SheetId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolyLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PolyLines_Sheets_SheetId",
                        column: x => x.SheetId,
                        principalTable: "Sheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "Type", "UserName" },
                values: new object[] { "1e8356cb-a0fd-4859-b483-9e0fd7489afb", 0, "4235646d-f8e0-43d3-bbce-1853194ff6f6", "admin@gmail.com", false, false, null, "admin", "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEHmWJA8DxCBUOdgk0W2v3AIp7CO671Fof1VP4ZVFBS6lXVprVMhXrnvCxN27yy0BXA==", null, false, "ab1b9f29-082b-44e0-a332-4e2b45346639", false, 0, "admin" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Address", "Name", "Phone" },
                values: new object[,]
                {
                    { new Guid("76ca6169-5587-4204-be0e-f45f9cb0288d"), "Rabat Agdal", "intelcap", "0666666666" },
                    { new Guid("84e8668b-7a49-4283-96aa-73b871f6e679"), "Rabat Technopolis", "novec", "0666666666" },
                    { new Guid("dce52084-ed68-4f9e-85f6-fdf5e20a45ad"), "Rabat Souissi", "ALGO Consulting", "0666666666" },
                    { new Guid("eb67c695-d666-4a5e-81b8-fd486d44672b"), "Rabat Technopolis", "Capgemini", "0666666666" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "ClientId", "FileName", "FilePath", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("1829a532-fcec-45a2-93b8-8bbb7a8eb9c0"), new Guid("eb67c695-d666-4a5e-81b8-fd486d44672b"), "cap2.pdf", "capProjects/cap2.pdf", "migration d'une application vers .Net Core", "1e8356cb-a0fd-4859-b483-9e0fd7489afb" },
                    { new Guid("27f07d89-745b-441c-9cf1-d9559f5294ed"), new Guid("dce52084-ed68-4f9e-85f6-fdf5e20a45ad"), "algo.pdf", "algoProjects/algo.pdf", "mise en place d'une architecture microservice", "1e8356cb-a0fd-4859-b483-9e0fd7489afb" },
                    { new Guid("c470b265-87c9-4447-a817-8269f052bc6c"), new Guid("84e8668b-7a49-4283-96aa-73b871f6e679"), "novec.pdf", "novecProjects/novec.pdf", "migration vers dotnet core", "1e8356cb-a0fd-4859-b483-9e0fd7489afb" },
                    { new Guid("d413951c-0a53-4531-adf5-a07838d7b966"), new Guid("eb67c695-d666-4a5e-81b8-fd486d44672b"), "cap.pdf", "capProjects/cap.pdf", "Création d'un dashboard", "1e8356cb-a0fd-4859-b483-9e0fd7489afb" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "MaterialId", "ProjectId" },
                values: new object[] { new Guid("c42ef423-2dd0-4b12-a05c-36cebcbdc114"), 2, new Guid("d413951c-0a53-4531-adf5-a07838d7b966") });

            migrationBuilder.InsertData(
                table: "Sheets",
                columns: new[] { "Id", "JobId", "Length", "Width" },
                values: new object[,]
                {
                    { new Guid("448d661f-f1ea-47d8-9080-ef060a5f5bcd"), new Guid("c42ef423-2dd0-4b12-a05c-36cebcbdc114"), 10.0, 10.0 },
                    { new Guid("47e5baa6-ac3d-4c5b-be21-4b1d3c32c7bd"), new Guid("c42ef423-2dd0-4b12-a05c-36cebcbdc114"), 12.0, 12.0 }
                });

            migrationBuilder.InsertData(
                table: "Circles",
                columns: new[] { "Id", "Radius", "SheetId", "xPosition", "yPosition" },
                values: new object[,]
                {
                    { new Guid("00c6a184-47f2-4b75-947c-415ee97445cf"), 10.0, new Guid("448d661f-f1ea-47d8-9080-ef060a5f5bcd"), 0.0, 1.0 },
                    { new Guid("0131f75d-b99c-4f88-8219-b7deed04b118"), 20.0, new Guid("448d661f-f1ea-47d8-9080-ef060a5f5bcd"), 12.0, 1.0 }
                });

            migrationBuilder.InsertData(
                table: "PolyLines",
                columns: new[] { "Id", "Bulge", "SheetId", "xPosition", "yPosition" },
                values: new object[] { new Guid("6fbf3f83-42d3-40f8-888d-cc5480b4933c"), 10.0, new Guid("448d661f-f1ea-47d8-9080-ef060a5f5bcd"), 10.0, 10.0 });

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
                name: "IX_Circles_SheetId",
                table: "Circles",
                column: "SheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ProjectId",
                table: "Jobs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PolyLines_SheetId",
                table: "PolyLines",
                column: "SheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientId",
                table: "Projects",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sheets_JobId",
                table: "Sheets",
                column: "JobId");
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
                name: "Circles");

            migrationBuilder.DropTable(
                name: "PolyLines");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Sheets");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
