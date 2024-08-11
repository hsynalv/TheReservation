using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantOwners_AppUsers_Id",
                table: "RestaurantOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_RestaurantOwners_OwnerId",
                table: "Restaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_AppUsers_Id",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantOwners",
                table: "RestaurantOwners");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "RestaurantOwners",
                newName: "RestaurantOwner");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantOwner",
                table: "RestaurantOwner",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AppUsers_Id",
                table: "Customers",
                column: "Id",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Customers_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantOwner_AppUsers_Id",
                table: "RestaurantOwner",
                column: "Id",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_RestaurantOwner_OwnerId",
                table: "Restaurants",
                column: "OwnerId",
                principalTable: "RestaurantOwner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Customers_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AppUsers_Id",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Customers_UserId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantOwner_AppUsers_Id",
                table: "RestaurantOwner");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_RestaurantOwner_OwnerId",
                table: "Restaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Customers_UserId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantOwner",
                table: "RestaurantOwner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "RestaurantOwner",
                newName: "RestaurantOwners");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantOwners",
                table: "RestaurantOwners",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantOwners_AppUsers_Id",
                table: "RestaurantOwners",
                column: "Id",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_RestaurantOwners_OwnerId",
                table: "Restaurants",
                column: "OwnerId",
                principalTable: "RestaurantOwners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AppUsers_Id",
                table: "Users",
                column: "Id",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
