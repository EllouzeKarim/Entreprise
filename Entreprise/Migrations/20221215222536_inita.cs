using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entreprise.Migrations
{
    /// <inheritdoc />
    public partial class inita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_User_HODId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_User_HODId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "User");

            migrationBuilder.CreateTable(
                name: "Hod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Firstname = table.Column<string>(type: "TEXT", nullable: true),
                    Lastname = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<int>(name: "Phone_Number", type: "INTEGER", nullable: false),
                    Function = table.Column<string>(type: "TEXT", nullable: true),
                    ROLE = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hod", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Hod_HODId",
                table: "Department",
                column: "HODId",
                principalTable: "Hod",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Hod_HODId",
                table: "Task",
                column: "HODId",
                principalTable: "Hod",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Hod_HODId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Hod_HODId",
                table: "Task");

            migrationBuilder.DropTable(
                name: "Hod");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "User",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_User_HODId",
                table: "Department",
                column: "HODId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_User_HODId",
                table: "Task",
                column: "HODId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
