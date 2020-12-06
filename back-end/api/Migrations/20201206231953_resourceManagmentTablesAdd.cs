using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class resourceManagmentTablesAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResourceDepartures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ResourceId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    CreationUserId = table.Column<int>(nullable: false),
                    DepartureDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceDepartures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceDepartures_Users_CreationUserId",
                        column: x => x.CreationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceDepartures_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ResourceId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    CreationUserId = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceEntries_Users_CreationUserId",
                        column: x => x.CreationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceEntries_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceStocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ResourceId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceStocks_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResourceDepartures_CreationUserId",
                table: "ResourceDepartures",
                column: "CreationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceDepartures_ResourceId",
                table: "ResourceDepartures",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceEntries_CreationUserId",
                table: "ResourceEntries",
                column: "CreationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceEntries_ResourceId",
                table: "ResourceEntries",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceStocks_ResourceId",
                table: "ResourceStocks",
                column: "ResourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResourceDepartures");

            migrationBuilder.DropTable(
                name: "ResourceEntries");

            migrationBuilder.DropTable(
                name: "ResourceStocks");
        }
    }
}
