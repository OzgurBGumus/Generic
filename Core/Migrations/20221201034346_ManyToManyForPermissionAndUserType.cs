using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P_Core.Migrations
{
    public partial class ManyToManyForPermissionAndUserType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserUserType_User_UserId",
                table: "UserUserType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserUserType",
                table: "UserUserType");

            migrationBuilder.DropIndex(
                name: "IX_UserUserType_UserTypesId",
                table: "UserUserType");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserUserType",
                newName: "UsersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserUserType",
                table: "UserUserType",
                columns: new[] { "UserTypesId", "UsersId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserUserType_UsersId",
                table: "UserUserType",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserUserType_User_UsersId",
                table: "UserUserType",
                column: "UsersId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserUserType_User_UsersId",
                table: "UserUserType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserUserType",
                table: "UserUserType");

            migrationBuilder.DropIndex(
                name: "IX_UserUserType_UsersId",
                table: "UserUserType");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "UserUserType",
                newName: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserUserType",
                table: "UserUserType",
                columns: new[] { "UserId", "UserTypesId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserUserType_UserTypesId",
                table: "UserUserType",
                column: "UserTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserUserType_User_UserId",
                table: "UserUserType",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
