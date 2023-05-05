using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSumForTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Sum",
                table: "transaction",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sum",
                table: "transaction");
        }
    }
}
