using Microsoft.EntityFrameworkCore.Migrations;

namespace ContaSimples.WebApi.Migrations
{
    public partial class MudancaTipoCampo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Conta",
                table: "ContaCorrente",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Agencia",
                table: "ContaCorrente",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Conta",
                table: "ContaCorrente",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "Agencia",
                table: "ContaCorrente",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
