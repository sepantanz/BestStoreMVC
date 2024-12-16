using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BestStoreMVC.Migrations
{
    /// <inheritdoc />
    public partial class PaymentDetailsFieldInOrderModelEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymanetDetails",
                table: "Orders",
                newName: "PaymentDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentDetails",
                table: "Orders",
                newName: "PaymanetDetails");
        }
    }
}
