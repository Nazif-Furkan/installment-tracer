using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AylikTaksit.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TransactionAmountEqualsInstallmentXInstallment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAmountFirstCalculation",
                table: "Transactions",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAmountFirstCalculation",
                table: "Transactions");
        }
    }
}
