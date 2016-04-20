using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace ToDoList.Migrations
{
    public partial class MakeTableNamesPlural : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Item_Category_CategoryId", table: "Item");
            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Items");
            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");
            migrationBuilder.AddForeignKey(
                name: "FK_Item_Category_CategoryId",
                table: "Items",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Item_Category_CategoryId", table: "Items");
            migrationBuilder.AddForeignKey(
                name: "FK_Item_Category_CategoryId",
                table: "Item",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Item");
            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");
        }
    }
}
