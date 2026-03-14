using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    CTENANT_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CTENANT_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CSUBSCRIPTION_PLAN = table.Column<int>(type: "int", nullable: false),
                    DCREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.CTENANT_ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    CUSER_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CUSER_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CEMAIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CUSER_ROLE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.CUSER_ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
