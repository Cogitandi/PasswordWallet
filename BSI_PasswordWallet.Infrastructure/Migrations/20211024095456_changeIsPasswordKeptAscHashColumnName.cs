using Microsoft.EntityFrameworkCore.Migrations;

namespace BSI_PasswordWallet.Infrastructure.Migrations
{
    public partial class changeIsPasswordKeptAscHashColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsPasswordKeptAsHash",
                table: "Users",
                newName: "IsPasswordKeptAsSHA512");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsPasswordKeptAsSHA512",
                table: "Users",
                newName: "IsPasswordKeptAsHash");
        }
    }
}
