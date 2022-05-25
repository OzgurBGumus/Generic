using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P_StartupV0001.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OGDate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Minute = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Second = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OGDate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JwtToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailConfirm = table.Column<bool>(type: "bit", nullable: false),
                    PhoneConfirm = table.Column<bool>(type: "bit", nullable: false),
                    BirthDateId = table.Column<int>(type: "int", nullable: true),
                    CreateDateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_OGDate_BirthDateId",
                        column: x => x.BirthDateId,
                        principalTable: "OGDate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_OGDate_CreateDateId",
                        column: x => x.CreateDateId,
                        principalTable: "OGDate",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permission_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserUserType",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUserType", x => new { x.UserId, x.UserTypesId });
                    table.ForeignKey(
                        name: "FK_UserUserType_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUserType_UserType_UserTypesId",
                        column: x => x.UserTypesId,
                        principalTable: "UserType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionUserType",
                columns: table => new
                {
                    PermissionsId = table.Column<int>(type: "int", nullable: false),
                    UserTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionUserType", x => new { x.PermissionsId, x.UserTypesId });
                    table.ForeignKey(
                        name: "FK_PermissionUserType_Permission_PermissionsId",
                        column: x => x.PermissionsId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionUserType_UserType_UserTypesId",
                        column: x => x.UserTypesId,
                        principalTable: "UserType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permission_StatusId",
                table: "Permission",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionUserType_UserTypesId",
                table: "PermissionUserType",
                column: "UserTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_User_BirthDateId",
                table: "User",
                column: "BirthDateId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CreateDateId",
                table: "User",
                column: "CreateDateId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUserType_UserTypesId",
                table: "UserUserType",
                column: "UserTypesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissionUserType");

            migrationBuilder.DropTable(
                name: "UserUserType");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "OGDate");
        }
    }
}
