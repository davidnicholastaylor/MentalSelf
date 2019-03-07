using Microsoft.EntityFrameworkCore.Migrations;

namespace MentalSelf.Migrations
{
    public partial class QTLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QTLink",
                table: "QuestionType",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "QuestionType",
                keyColumn: "QuestionTypeId",
                keyValue: 1,
                column: "QTLink",
                value: "");

            migrationBuilder.UpdateData(
                table: "QuestionType",
                keyColumn: "QuestionTypeId",
                keyValue: 2,
                column: "QTLink",
                value: "");

            migrationBuilder.UpdateData(
                table: "QuestionType",
                keyColumn: "QuestionTypeId",
                keyValue: 3,
                column: "QTLink",
                value: "");

            migrationBuilder.UpdateData(
                table: "QuestionType",
                keyColumn: "QuestionTypeId",
                keyValue: 4,
                column: "QTLink",
                value: "");

            migrationBuilder.UpdateData(
                table: "QuestionType",
                keyColumn: "QuestionTypeId",
                keyValue: 5,
                column: "QTLink",
                value: "");

            migrationBuilder.UpdateData(
                table: "QuestionType",
                keyColumn: "QuestionTypeId",
                keyValue: 6,
                column: "QTLink",
                value: "");

            migrationBuilder.UpdateData(
                table: "QuestionType",
                keyColumn: "QuestionTypeId",
                keyValue: 7,
                column: "QTLink",
                value: "");

            migrationBuilder.UpdateData(
                table: "QuestionType",
                keyColumn: "QuestionTypeId",
                keyValue: 8,
                column: "QTLink",
                value: "");

            migrationBuilder.UpdateData(
                table: "QuestionType",
                keyColumn: "QuestionTypeId",
                keyValue: 9,
                column: "QTLink",
                value: "");

            migrationBuilder.UpdateData(
                table: "QuestionType",
                keyColumn: "QuestionTypeId",
                keyValue: 10,
                column: "QTLink",
                value: "");

            migrationBuilder.UpdateData(
                table: "QuestionType",
                keyColumn: "QuestionTypeId",
                keyValue: 11,
                column: "QTLink",
                value: "");

            migrationBuilder.UpdateData(
                table: "QuestionType",
                keyColumn: "QuestionTypeId",
                keyValue: 12,
                column: "QTLink",
                value: "");

            migrationBuilder.UpdateData(
                table: "QuestionType",
                keyColumn: "QuestionTypeId",
                keyValue: 13,
                column: "QTLink",
                value: "");

            migrationBuilder.UpdateData(
                table: "QuestionType",
                keyColumn: "QuestionTypeId",
                keyValue: 14,
                column: "QTLink",
                value: "");

            migrationBuilder.UpdateData(
                table: "QuestionType",
                keyColumn: "QuestionTypeId",
                keyValue: 15,
                column: "QTLink",
                value: "");

            migrationBuilder.UpdateData(
                table: "QuestionType",
                keyColumn: "QuestionTypeId",
                keyValue: 16,
                column: "QTLink",
                value: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QTLink",
                table: "QuestionType");
        }
    }
}
