using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WalletApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialTransactionAndIcon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "icons",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    icon_url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_icons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "transaction",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    owner_id = table.Column<Guid>(type: "uuid", nullable: false),
                    type_transaction = table.Column<int>(type: "integer", nullable: false),
                    date_transaction = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_pending = table.Column<bool>(type: "boolean", nullable: false),
                    sender_name = table.Column<string>(type: "text", nullable: false),
                    icon_id = table.Column<int>(type: "integer", nullable: true),
                    Sum = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaction", x => x.id);
                    table.ForeignKey(
                        name: "FK_transaction_icons_icon_id",
                        column: x => x.icon_id,
                        principalTable: "icons",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_transaction_users_owner_id",
                        column: x => x.owner_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_transaction_icon_id",
                table: "transaction",
                column: "icon_id");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_owner_id",
                table: "transaction",
                column: "owner_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transaction");

            migrationBuilder.DropTable(
                name: "icons");
        }
    }
}
