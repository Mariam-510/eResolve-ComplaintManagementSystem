using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComplaintManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class updates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "Username" },
                values: new object[] { "21IVrh2geWvBeF7CLV8XueyHnIzwPJcbF4yaNKMxqzY=", "Mariam" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "PasswordHash", "Role", "Username" },
                values: new object[] { 2, new DateTime(2025, 1, 20, 9, 50, 0, 0, DateTimeKind.Unspecified), false, "tN0e8KkaiYylZetJrEQdFJ+3XY0IOpPSrN9c3VBL6RE=", "Employee", "Hoda" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AccountId", "CityId", "DateOfBirth", "DepartmentId", "IsDeleted", "Name", "PhoneNumber", "Salary" },
                values: new object[] { 2, 2, 3, new DateTime(2001, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Hoda", "01144890255", 5000.00m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "Username" },
                values: new object[] { "dnaqr7AnyCW9mrq3iyNAcOcCdS9iW3UuVeVbSOYH41g=", "Admin1" });
        }
    }
}
