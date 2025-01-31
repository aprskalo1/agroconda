using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgrocondaAPI.Migrations
{
    /// <inheritdoc />
    public partial class ModelsRelationsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssignedItemParcels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AssignedItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    ParcelId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedItemParcels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignedItemParcels_AssignedItems_AssignedItemId",
                        column: x => x.AssignedItemId,
                        principalTable: "AssignedItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedItemParcels_Parcels_ParcelId",
                        column: x => x.ParcelId,
                        principalTable: "Parcels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParcelGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ParcelId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParcelGroups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParcelGroups_Parcels_ParcelId",
                        column: x => x.ParcelId,
                        principalTable: "Parcels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignedItemParcels_AssignedItemId",
                table: "AssignedItemParcels",
                column: "AssignedItemId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedItemParcels_ParcelId",
                table: "AssignedItemParcels",
                column: "ParcelId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelGroups_GroupId",
                table: "ParcelGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelGroups_ParcelId",
                table: "ParcelGroups",
                column: "ParcelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignedItemParcels");

            migrationBuilder.DropTable(
                name: "ParcelGroups");
        }
    }
}
