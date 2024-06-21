using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestWebApi.Migrations
{
    /// <inheritdoc />
    public partial class thirdmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StateAndCapitals_Capitals_CapitalId",
                table: "StateAndCapitals");

            migrationBuilder.DropForeignKey(
                name: "FK_StateAndCapitals_States_StateId",
                table: "StateAndCapitals");

            migrationBuilder.DropIndex(
                name: "IX_StateAndCapitals_CapitalId",
                table: "StateAndCapitals");

            migrationBuilder.DropIndex(
                name: "IX_StateAndCapitals_StateId",
                table: "StateAndCapitals");

            migrationBuilder.DropColumn(
                name: "CapitalId",
                table: "StateAndCapitals");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "StateAndCapitals");

            migrationBuilder.AddColumn<string>(
                name: "CapitalName",
                table: "StateAndCapitals",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "StateName",
                table: "StateAndCapitals",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CapitalName",
                table: "StateAndCapitals");

            migrationBuilder.DropColumn(
                name: "StateName",
                table: "StateAndCapitals");

            migrationBuilder.AddColumn<Guid>(
                name: "CapitalId",
                table: "StateAndCapitals",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StateId",
                table: "StateAndCapitals",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_StateAndCapitals_CapitalId",
                table: "StateAndCapitals",
                column: "CapitalId");

            migrationBuilder.CreateIndex(
                name: "IX_StateAndCapitals_StateId",
                table: "StateAndCapitals",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_StateAndCapitals_Capitals_CapitalId",
                table: "StateAndCapitals",
                column: "CapitalId",
                principalTable: "Capitals",
                principalColumn: "CapitalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StateAndCapitals_States_StateId",
                table: "StateAndCapitals",
                column: "StateId",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
