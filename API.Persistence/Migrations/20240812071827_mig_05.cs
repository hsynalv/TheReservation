using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Restaurants",
                newName: "RestaurantPhoneNumber");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "RestaurantOwner",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RestaurantOwner",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "RestaurantOwner");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "RestaurantOwner");

            migrationBuilder.RenameColumn(
                name: "RestaurantPhoneNumber",
                table: "Restaurants",
                newName: "PhoneNumber");
        }
    }
}
