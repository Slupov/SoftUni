using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace _02.SocialNetwork.Migrations
{
    public partial class friendships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friendships");

            migrationBuilder.AddColumn<int>(
                name: "AlbumId1",
                table: "AlbumsPhotographers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Friendship",
                columns: table => new
                {
                    FromPhotographerId = table.Column<int>(type: "int", nullable: false),
                    ToPhotographerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendship", x => new { x.FromPhotographerId, x.ToPhotographerId });
                    table.ForeignKey(
                        name: "FK_Friendship_Photographers_FromPhotographerId",
                        column: x => x.FromPhotographerId,
                        principalTable: "Photographers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Friendship_Photographers_ToPhotographerId",
                        column: x => x.ToPhotographerId,
                        principalTable: "Photographers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlbumsPhotographers_AlbumId1",
                table: "AlbumsPhotographers",
                column: "AlbumId1");

            migrationBuilder.CreateIndex(
                name: "IX_Friendship_ToPhotographerId",
                table: "Friendship",
                column: "ToPhotographerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumsPhotographers_Albums_AlbumId1",
                table: "AlbumsPhotographers",
                column: "AlbumId1",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumsPhotographers_Albums_AlbumId1",
                table: "AlbumsPhotographers");

            migrationBuilder.DropTable(
                name: "Friendship");

            migrationBuilder.DropIndex(
                name: "IX_AlbumsPhotographers_AlbumId1",
                table: "AlbumsPhotographers");

            migrationBuilder.DropColumn(
                name: "AlbumId1",
                table: "AlbumsPhotographers");

            migrationBuilder.CreateTable(
                name: "Friendships",
                columns: table => new
                {
                    Photographer1Id = table.Column<int>(nullable: false),
                    Photographer2Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendships", x => new { x.Photographer1Id, x.Photographer2Id });
                    table.ForeignKey(
                        name: "FK_Friendships_Photographers_Photographer1Id",
                        column: x => x.Photographer1Id,
                        principalTable: "Photographers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Friendships_Photographers_Photographer2Id",
                        column: x => x.Photographer2Id,
                        principalTable: "Photographers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_Photographer2Id",
                table: "Friendships",
                column: "Photographer2Id");
        }
    }
}
