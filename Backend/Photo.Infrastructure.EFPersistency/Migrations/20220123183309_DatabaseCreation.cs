using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Photo.Infrastructure.EFPersistency.Migrations
{
    public partial class DatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhotoImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LargeThumbnailURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MediumThumbnailURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmallThumbnailURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Signature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WasProcessed = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoImages", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhotoImages");
        }
    }
}
