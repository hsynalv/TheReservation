using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "RestaurantOwner");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Customers");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Customers");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Reviews",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Restaurants",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "RestaurantOwner",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Menus",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Dishes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Customers",
                type: "datetime2",
                nullable: true);
        }
    }
}
