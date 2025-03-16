using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectDeAnTW.Migrations
{
    /// <inheritdoc />
    public partial class AddDiscriminatorColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarneSiMezeluri");

            migrationBuilder.DropTable(
                name: "Dulciuri");

            migrationBuilder.DropTable(
                name: "Fructe");

            migrationBuilder.DropTable(
                name: "Legume");

            migrationBuilder.DropTable(
                name: "Paste");

            migrationBuilder.DropTable(
                name: "Peste");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Aliment",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Aliment");

            migrationBuilder.CreateTable(
                name: "CarneSiMezeluri",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarneSiMezeluri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarneSiMezeluri_Aliment_Id",
                        column: x => x.Id,
                        principalTable: "Aliment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dulciuri",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dulciuri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dulciuri_Aliment_Id",
                        column: x => x.Id,
                        principalTable: "Aliment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fructe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fructe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fructe_Aliment_Id",
                        column: x => x.Id,
                        principalTable: "Aliment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Legume",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Legume", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Legume_Aliment_Id",
                        column: x => x.Id,
                        principalTable: "Aliment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paste",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paste", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paste_Aliment_Id",
                        column: x => x.Id,
                        principalTable: "Aliment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Peste",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peste", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Peste_Aliment_Id",
                        column: x => x.Id,
                        principalTable: "Aliment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
