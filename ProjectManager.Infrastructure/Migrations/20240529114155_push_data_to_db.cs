using Microsoft.EntityFrameworkCore.Migrations;
using ProjectManager.Domain.Entities;

#nullable disable

namespace ProjectManager.Infrastructure.Migrations
{
    public partial class push_data_to_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Adding sample data to ProjectEntity
            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Cipher", "Name" },
                values: new object[,]
                {
                    { 1, "PRJ001", "Project Alpha" },
                    { 2, "PRJ002", "Project Beta" },
                    { 3, "PRJ003", "Project Gamma" },
                    { 4, "PRJ004", "Project Delta" },
                    { 5, "PRJ005", "Project Epsilon" }
                });

            // Adding sample data to DesignObjectEntity
            migrationBuilder.InsertData(
                table: "DesignObjects",
                columns: new[] { "Id", "ProjectId", "ParentDesignObjectId", "Code", "Name" },
                values: new object[,]
                {
                    { 1, 1, null, "DO001", "Design Object 1 - first layer" },
                    { 2, 1, null, "DO002", "Design Object 2 - first layer" },
                    { 3, 2, null, "DO003", "Design Object 3 - first layer" },
                    { 4, 2, 3, "DO004", "Design Object 4 - second layer" },
                    { 5, 3, null, "DO005", "Design Object 5 - first layer" },
                    { 6, 3, 5, "DO006", "Design Object 6 - second layer" },
                    { 7, 4, null, "DO007", "Design Object 7 - first layer" },
                    { 8, 4, 7, "DO008", "Design Object 8 - second layer" },
                    { 9, 4, 8, "DO009", "Design Object 9 - third layer" },
                    { 10, 5, null, "DO010", "Design Object 10 - first layer" },
                    { 11, 5, 10, "DO011", "Design Object 11 - second layer" },
                    { 12, 5, 11, "DO012", "Design Object 12 - third layer" }
                });

            // Adding sample data to DocSetEntity
            migrationBuilder.InsertData(
                table: "DocSets",
                columns: new[] { "Id", "DesignObjectId", "Mark", "Number" },
                values: new object[,]
                {
                    { 1, 1, "TX", 0 },
                    { 2, 1, "AC", 1 },
                    { 3, 1, "CM", 2 },
                    { 4, 2, "TX", 0 },
                    { 5, 2, "AC", 1 },
                    { 6, 2, "CM", 2 },
                    { 7, 3, "TX", 0 },
                    { 8, 3, "AC", 1 },
                    { 9, 4, "TX", 0 },
                    { 10, 4, "AC", 1 },
                    { 11, 4, "CM", 2 },
                    { 12, 5, "TX", 0 },
                    { 13, 5, "AC", 1 },
                    { 14, 6, "TX", 0 },
                    { 15, 6, "AC", 1 },
                    { 16, 6, "CM", 2 },
                    { 17, 7, "TX", 0 },
                    { 18, 7, "AC", 1 },
                    { 19, 8, "TX", 0 },
                    { 20, 8, "AC", 1 },
                    { 21, 8, "CM", 2 },
                    { 22, 9, "TX", 0 },
                    { 23, 9, "AC", 1 },
                    { 24, 9, "CM", 2 },
                    { 25, 10, "TX", 0 },
                    { 26, 10, "AC", 1 },
                    { 27, 11, "TX", 0 },
                    { 28, 11, "AC", 1 },
                    { 29, 11, "CM", 2 },
                    { 30, 12, "TX", 0 },
                    { 31, 12, "AC", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove data
            migrationBuilder.DeleteData(
                table: "DocSets",
                keyColumn: "Id",
                keyValues: new object[]
                {
                    1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
                    13, 14, 15, 16, 17, 18, 19, 20, 21, 22,
                    23, 24, 25, 26, 27, 28, 29, 30, 31
                });

            migrationBuilder.DeleteData(
                table: "DesignObjects",
                keyColumn: "Id",
                keyValues: new object[]
                {
                    1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12
                });

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5 });
        }
    }
}
