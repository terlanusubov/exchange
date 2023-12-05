using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exchange.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OperationTableChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TargetCurrency",
                table: "Operations",
                newName: "To");

            migrationBuilder.RenameColumn(
                name: "AmountInUSD",
                table: "Operations",
                newName: "Amount");

            migrationBuilder.AddColumn<string>(
                name: "From",
                table: "Operations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "From",
                table: "Operations");

            migrationBuilder.RenameColumn(
                name: "To",
                table: "Operations",
                newName: "TargetCurrency");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Operations",
                newName: "AmountInUSD");
        }
    }
}
