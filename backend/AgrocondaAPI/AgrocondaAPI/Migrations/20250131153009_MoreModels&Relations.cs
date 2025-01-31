using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgrocondaAPI.Migrations
{
    /// <inheritdoc />
    public partial class MoreModelsRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AgroNote",
                table: "AgroNote");

            migrationBuilder.RenameTable(
                name: "AgroNote",
                newName: "AgroNotes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AgroNotes",
                table: "AgroNotes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AgroTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ParcelId = table.Column<Guid>(type: "uuid", nullable: false),
                    TaskName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgroTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgroTasks_Parcels_ParcelId",
                        column: x => x.ParcelId,
                        principalTable: "Parcels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Base64Image = table.Column<string>(type: "text", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    MimeType = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssignedItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AssignerId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssignedId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssignNote = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignedItems_Users_AssignedId",
                        column: x => x.AssignedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedItems_Users_AssignerId",
                        column: x => x.AssignerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Crops",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ParcelId = table.Column<Guid>(type: "uuid", nullable: false),
                    CropType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    SowingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Crops_Parcels_ParcelId",
                        column: x => x.ParcelId,
                        principalTable: "Parcels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssignedItemCrops",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AssignedItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    CropId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedItemCrops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignedItemCrops_AssignedItems_AssignedItemId",
                        column: x => x.AssignedItemId,
                        principalTable: "AssignedItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedItemCrops_Crops_CropId",
                        column: x => x.CropId,
                        principalTable: "Crops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CropAgroNotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CropId = table.Column<Guid>(type: "uuid", nullable: false),
                    AgroNoteId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CropAgroNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CropAgroNotes_AgroNotes_AgroNoteId",
                        column: x => x.AgroNoteId,
                        principalTable: "AgroNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CropAgroNotes_Crops_CropId",
                        column: x => x.CropId,
                        principalTable: "Crops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CropAssets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CropId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssetId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CropAssets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CropAssets_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CropAssets_Crops_CropId",
                        column: x => x.CropId,
                        principalTable: "Crops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssignedItemGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AssignedItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedItemGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignedItemGroups_AssignedItems_AssignedItemId",
                        column: x => x.AssignedItemId,
                        principalTable: "AssignedItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedItemGroups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CropGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CropId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CropGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CropGroups_Crops_CropId",
                        column: x => x.CropId,
                        principalTable: "Crops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CropGroups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgroTasks_ParcelId",
                table: "AgroTasks",
                column: "ParcelId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedItemCrops_AssignedItemId",
                table: "AssignedItemCrops",
                column: "AssignedItemId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedItemCrops_CropId",
                table: "AssignedItemCrops",
                column: "CropId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedItemGroups_AssignedItemId",
                table: "AssignedItemGroups",
                column: "AssignedItemId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedItemGroups_GroupId",
                table: "AssignedItemGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedItems_AssignedId",
                table: "AssignedItems",
                column: "AssignedId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedItems_AssignerId",
                table: "AssignedItems",
                column: "AssignerId");

            migrationBuilder.CreateIndex(
                name: "IX_CropAgroNotes_AgroNoteId",
                table: "CropAgroNotes",
                column: "AgroNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_CropAgroNotes_CropId",
                table: "CropAgroNotes",
                column: "CropId");

            migrationBuilder.CreateIndex(
                name: "IX_CropAssets_AssetId",
                table: "CropAssets",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_CropAssets_CropId",
                table: "CropAssets",
                column: "CropId");

            migrationBuilder.CreateIndex(
                name: "IX_CropGroups_CropId",
                table: "CropGroups",
                column: "CropId");

            migrationBuilder.CreateIndex(
                name: "IX_CropGroups_GroupId",
                table: "CropGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_ParcelId",
                table: "Crops",
                column: "ParcelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgroTasks");

            migrationBuilder.DropTable(
                name: "AssignedItemCrops");

            migrationBuilder.DropTable(
                name: "AssignedItemGroups");

            migrationBuilder.DropTable(
                name: "CropAgroNotes");

            migrationBuilder.DropTable(
                name: "CropAssets");

            migrationBuilder.DropTable(
                name: "CropGroups");

            migrationBuilder.DropTable(
                name: "AssignedItems");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Crops");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AgroNotes",
                table: "AgroNotes");

            migrationBuilder.RenameTable(
                name: "AgroNotes",
                newName: "AgroNote");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AgroNote",
                table: "AgroNote",
                column: "Id");
        }
    }
}
