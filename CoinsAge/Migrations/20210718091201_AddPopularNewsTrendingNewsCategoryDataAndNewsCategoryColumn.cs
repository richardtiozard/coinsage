using Microsoft.EntityFrameworkCore.Migrations;

namespace CoinsAge.Migrations
{
    public partial class AddPopularNewsTrendingNewsCategoryDataAndNewsCategoryColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "News",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "PopularNews",
                columns: table => new
                {
                    PopularNewsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PopularNews", x => x.PopularNewsId);
                    table.ForeignKey(
                        name: "FK_PopularNews_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "NewsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrendingNews",
                columns: table => new
                {
                    TrendingNewsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrendingNews", x => x.TrendingNewsId);
                    table.ForeignKey(
                        name: "FK_TrendingNews_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "NewsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_News_CategoryId",
                table: "News",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PopularNews_NewsId",
                table: "PopularNews",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_TrendingNews_NewsId",
                table: "TrendingNews",
                column: "NewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Category_CategoryId",
                table: "News",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Category_CategoryId",
                table: "News");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "PopularNews");

            migrationBuilder.DropTable(
                name: "TrendingNews");

            migrationBuilder.DropIndex(
                name: "IX_News_CategoryId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "News");
        }
    }
}
