using Microsoft.EntityFrameworkCore.Migrations;

namespace MT.OnlineRestaurant.DataLayer.Migrations
{
    public partial class Stock_Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblStock_TblRestaurant",
                table: "tblStock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblStock",
                table: "tblStock");

            migrationBuilder.DropIndex(
                name: "IX_tblStock_RestaurantID",
                table: "tblStock");

            migrationBuilder.RenameTable(
                name: "tblStock",
                newName: "TblStock");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "TblStock",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "TblRestaurantId",
                table: "TblStock",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblStock",
                table: "TblStock",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TblStock_TblRestaurantId",
                table: "TblStock",
                column: "TblRestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblStock_tblRestaurant_TblRestaurantId",
                table: "TblStock",
                column: "TblRestaurantId",
                principalTable: "tblRestaurant",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblStock_tblRestaurant_TblRestaurantId",
                table: "TblStock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblStock",
                table: "TblStock");

            migrationBuilder.DropIndex(
                name: "IX_TblStock_TblRestaurantId",
                table: "TblStock");

            migrationBuilder.DropColumn(
                name: "TblRestaurantId",
                table: "TblStock");

            migrationBuilder.RenameTable(
                name: "TblStock",
                newName: "tblStock");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tblStock",
                newName: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblStock",
                table: "tblStock",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_tblStock_RestaurantID",
                table: "tblStock",
                column: "RestaurantID");

            migrationBuilder.AddForeignKey(
                name: "FK_TblStock_TblRestaurant",
                table: "tblStock",
                column: "RestaurantID",
                principalTable: "tblRestaurant",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
