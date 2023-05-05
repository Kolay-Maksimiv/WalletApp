using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIconForTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transaction_icons_icon_id",
                table: "transaction");

            migrationBuilder.AlterColumn<int>(
                name: "icon_id",
                table: "transaction",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_icons_icon_id",
                table: "transaction",
                column: "icon_id",
                principalTable: "icons",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transaction_icons_icon_id",
                table: "transaction");

            migrationBuilder.AlterColumn<int>(
                name: "icon_id",
                table: "transaction",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_icons_icon_id",
                table: "transaction",
                column: "icon_id",
                principalTable: "icons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
