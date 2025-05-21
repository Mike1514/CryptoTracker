using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoTracker.Fetcher.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Price_Record_Editing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "PriceRecords");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "PriceRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
