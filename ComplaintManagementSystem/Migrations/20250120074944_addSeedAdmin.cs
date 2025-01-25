using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComplaintManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class addSeedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "CreatedAt", "PasswordHash", "Role", "Username" },
                values: new object[] { 1, new DateTime(2025, 1, 20, 9, 50, 0, 0, DateTimeKind.Unspecified), "dnaqr7AnyCW9mrq3iyNAcOcCdS9iW3UuVeVbSOYH41g=", "Admin", "Admin1" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AccountId", "CityId", "DateOfBirth", "DepartmentId", "Name", "PhoneNumber", "Salary" },
                values: new object[] { 1, 1, 6, new DateTime(2002, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mariam Ashraf", "01144456820", 10000.00m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
