using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComplaintManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class addPhoneConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_Employee_PhoneNumber_Length",
                table: "Employees",
                sql: "LEN([PhoneNumber]) BETWEEN 11 AND 15");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Complaint_PhoneNumber_Length",
                table: "Complaints",
                sql: "LEN([PhoneNumber]) BETWEEN 11 AND 15");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Citizen_PhoneNumber_Length",
                table: "Citizens",
                sql: "LEN([PhoneNumber]) BETWEEN 11 AND 15");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Employee_PhoneNumber_Length",
                table: "Employees");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Complaint_PhoneNumber_Length",
                table: "Complaints");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Citizen_PhoneNumber_Length",
                table: "Citizens");
        }
    }
}
