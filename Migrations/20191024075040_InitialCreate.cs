using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trendlogg.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Channels",
                columns: table => new
                {
                    Channel_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TimeZone = table.Column<DateTime>(nullable: false),
                    LifeTime = table.Column<int>(nullable: false),
                    Latitude = table.Column<int>(nullable: false),
                    Longitude = table.Column<int>(nullable: false),
                    Elevation = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    MaxSize = table.Column<int>(nullable: false),
                    PCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channels", x => x.Channel_ID);
                });

            migrationBuilder.CreateTable(
                name: "Feeds",
                columns: table => new
                {
                    PointID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    Scale = table.Column<int>(nullable: false),
                    Alarm = table.Column<int>(nullable: false),
                    Enable_Alarm = table.Column<int>(nullable: false),
                    AlarmSettings = table.Column<string>(nullable: true),
                    Channel_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feeds", x => x.PointID);
                    table.ForeignKey(
                        name: "FK_Feeds_Channels_Channel_ID",
                        column: x => x.Channel_ID,
                        principalTable: "Channels",
                        principalColumn: "Channel_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    PointID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    Value = table.Column<int>(nullable: false),
                    FeedPointID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.PointID);
                    table.ForeignKey(
                        name: "FK_Points_Feeds_FeedPointID",
                        column: x => x.FeedPointID,
                        principalTable: "Feeds",
                        principalColumn: "PointID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feeds_Channel_ID",
                table: "Feeds",
                column: "Channel_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Points_FeedPointID",
                table: "Points",
                column: "FeedPointID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropTable(
                name: "Feeds");

            migrationBuilder.DropTable(
                name: "Channels");
        }
    }
}
