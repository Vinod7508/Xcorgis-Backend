using Microsoft.EntityFrameworkCore.Migrations;

namespace Xcorgis.DataAccess.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(maxLength: 50, nullable: false),
                    AdditionalInformation = table.Column<string>(maxLength: 200, nullable: true),
                    isActive = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductDesc = table.Column<string>(maxLength: 50, nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Allow_Web_Sales = table.Column<bool>(nullable: false, defaultValue: true),
                    isActive = table.Column<bool>(nullable: false, defaultValue: true),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductCode);
                    table.ForeignKey(
                        name: "FK_Products_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "AdditionalInformation", "DepartmentName" },
                values: new object[] { 1, "Mens Special", "Mens" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "AdditionalInformation", "DepartmentName" },
                values: new object[] { 2, "Woman Special", "Woman" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductCode", "DepartmentId", "Price", "ProductDesc" },
                values: new object[] { 1, 1, 8.0, "T-shit" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductCode", "DepartmentId", "Price", "ProductDesc" },
                values: new object[] { 2, 2, 30.0, "Booties" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_DepartmentId",
                table: "Products",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
