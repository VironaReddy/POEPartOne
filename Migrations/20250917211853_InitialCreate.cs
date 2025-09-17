using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POEOne.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileUpLoad",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileUpLoad", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Lecturer",
                columns: table => new
                {
                    LecturerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LecturerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LecturerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoursTaught = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturer", x => x.LecturerID);
                });

            migrationBuilder.CreateTable(
                name: "ClaimApproval",
                columns: table => new
                {
                    ClaimApprovalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Approver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approve = table.Column<int>(type: "int", nullable: false),
                    LecturerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimApproval", x => x.ClaimApprovalId);
                    table.ForeignKey(
                        name: "FK_ClaimApproval_Lecturer_LecturerID",
                        column: x => x.LecturerID,
                        principalTable: "Lecturer",
                        principalColumn: "LecturerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    ClaimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LecturerID = table.Column<int>(type: "int", nullable: false),
                    ClaimApprovalId = table.Column<int>(type: "int", nullable: true),
                    Approve = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.ClaimId);
                    table.ForeignKey(
                        name: "FK_Status_ClaimApproval_ClaimApprovalId",
                        column: x => x.ClaimApprovalId,
                        principalTable: "ClaimApproval",
                        principalColumn: "ClaimApprovalId");
                    table.ForeignKey(
                        name: "FK_Status_Lecturer_LecturerID",
                        column: x => x.LecturerID,
                        principalTable: "Lecturer",
                        principalColumn: "LecturerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClaimApproval_LecturerID",
                table: "ClaimApproval",
                column: "LecturerID");

            migrationBuilder.CreateIndex(
                name: "IX_Status_ClaimApprovalId",
                table: "Status",
                column: "ClaimApprovalId");

            migrationBuilder.CreateIndex(
                name: "IX_Status_LecturerID",
                table: "Status",
                column: "LecturerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileUpLoad");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "ClaimApproval");

            migrationBuilder.DropTable(
                name: "Lecturer");
        }
    }
}
