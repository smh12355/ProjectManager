using Microsoft.EntityFrameworkCore.Migrations;
using ProjectManager.Domain.Models;

#nullable disable

namespace ProjectManager.Infrastructure.Migrations
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Adding Projects
            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Cipher", "Name" },
                values: new object[,]
                {
                    { 1, "P001", "Project One" },
                    { 2, "P002", "Project Two" },
                    { 3, "P003", "Project Three" },
                    { 4, "P004", "Project Four" },
                    { 5, "P005", "Project Five" }
                }
            );

            // Adding DesignObjects
            migrationBuilder.InsertData(
                table: "DesignObjects",
                columns: new[] { "Id", "ProjectId", "Code", "Name" },
                values: new object[,]
                {
                    { 1, 1, "D001", "Design Object One" },
                    { 2, 1, "D002", "Design Object Two" },
                    { 3, 2, "D003", "Design Object Three" },
                    { 4, 2, "D004", "Design Object Four" },
                    { 5, 3, "D005", "Design Object Five" },
                    { 6, 3, "D006", "Design Object Six" },
                    { 7, 4, "D007", "Design Object Seven" },
                    { 8, 4, "D008", "Design Object Eight" },
                    { 9, 5, "D009", "Design Object Nine" },
                    { 10, 5, "D010", "Design Object Ten" }
                }
            );

            // Adding DocSets
            migrationBuilder.InsertData(
                table: "DocSets",
                columns: new[] { "Id", "DesignObjectId", "Mark", "Number" },
                values: new object[,]
                {
                    { 1, 1, (int)Mark.TX, 100 },
                    { 2, 1, (int)Mark.AC, 200 },
                    { 3, 2, (int)Mark.CM, 150 },
                    { 4, 2, (int)Mark.TX, 250 },
                    { 5, 3, (int)Mark.AC, 300 },
                    { 6, 3, (int)Mark.CM, 350 },
                    { 7, 4, (int)Mark.TX, 400 },
                    { 8, 4, (int)Mark.AC, 450 },
                    { 9, 5, (int)Mark.CM, 500 },
                    { 10, 5, (int)Mark.TX, 550 },
                    { 11, 6, (int)Mark.AC, 600 },
                    { 12, 6, (int)Mark.CM, 650 },
                    { 13, 7, (int)Mark.TX, 700 },
                    { 14, 7, (int)Mark.AC, 750 },
                    { 15, 8, (int)Mark.CM, 800 },
                    { 16, 8, (int)Mark.TX, 850 },
                    { 17, 9, (int)Mark.AC, 900 },
                    { 18, 9, (int)Mark.CM, 950 },
                    { 19, 10, (int)Mark.TX, 1000 },
                    { 20, 10, (int)Mark.AC, 1050 }
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Removing DocSets
            migrationBuilder.DeleteData(
                table: "DocSets",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }
            );

            // Removing DesignObjects
            migrationBuilder.DeleteData(
                table: "DesignObjects",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
            );

            // Removing Projects
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5 }
            );
        }
    }
}
