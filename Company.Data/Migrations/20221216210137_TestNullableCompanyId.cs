using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company.Data.Migrations
{
    public partial class TestNullableCompanyId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Company_CompanyId",
                table: "Department");

            migrationBuilder.DeleteData(
                table: "EmployeeJobTitle",
                keyColumns: new[] { "EmployeeId", "JobTitleId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "EmployeeJobTitle",
                keyColumns: new[] { "EmployeeId", "JobTitleId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "EmployeeJobTitle",
                keyColumns: new[] { "EmployeeId", "JobTitleId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "EmployeeJobTitle",
                keyColumns: new[] { "EmployeeId", "JobTitleId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "EmployeeJobTitle",
                keyColumns: new[] { "EmployeeId", "JobTitleId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "JobTitle",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JobTitle",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JobTitle",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "JobTitle",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Department",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Company_CompanyId",
                table: "Department",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Company_CompanyId",
                table: "Department");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Department",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "Name", "Organisationsnummer" },
                values: new object[,]
                {
                    { 1, "Pendant publishing", "550 6600" },
                    { 2, "Weyland-Yutani", "551 6622" }
                });

            migrationBuilder.InsertData(
                table: "JobTitle",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Corporal" },
                    { 2, "Warrant officer" },
                    { 3, "Crewmember" },
                    { 4, "Copy Editor" }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "CompanyId", "DepartmentName" },
                values: new object[] { 1, 2, "Shipbuilding" });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "CompanyId", "DepartmentName" },
                values: new object[] { 2, 1, "Editorial Department" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "DepartmentId", "FirstName", "LastName", "Salary", "Unionized" },
                values: new object[] { 1, 1, "Ellen", "Ripley", 1000, false });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "DepartmentId", "FirstName", "LastName", "Salary", "Unionized" },
                values: new object[] { 2, 2, "Elaine", "Benes", 10000, false });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "DepartmentId", "FirstName", "LastName", "Salary", "Unionized" },
                values: new object[] { 3, 1, "Dwayne", "Hicks", 100, true });

            migrationBuilder.InsertData(
                table: "EmployeeJobTitle",
                columns: new[] { "EmployeeId", "JobTitleId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 4 },
                    { 3, 1 },
                    { 3, 3 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Company_CompanyId",
                table: "Department",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
