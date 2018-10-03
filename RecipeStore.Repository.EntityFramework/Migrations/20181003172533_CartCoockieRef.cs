using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RecipeStore.Repository.EntityFramework.Migrations
{
    public partial class CartCoockieRef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeItem_Ingredient_IngredientId",
                table: "RecipeItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItem_Ingredient_IngredientId",
                table: "ShoppingCartItem");

            migrationBuilder.AlterColumn<Guid>(
                name: "IngredientId",
                table: "ShoppingCartItem",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CartRefCookie",
                table: "ShoppingCart",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IngredientId",
                table: "RecipeItem",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeItem_Ingredient_IngredientId",
                table: "RecipeItem",
                column: "IngredientId",
                principalTable: "Ingredient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItem_Ingredient_IngredientId",
                table: "ShoppingCartItem",
                column: "IngredientId",
                principalTable: "Ingredient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeItem_Ingredient_IngredientId",
                table: "RecipeItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItem_Ingredient_IngredientId",
                table: "ShoppingCartItem");

            migrationBuilder.DropColumn(
                name: "CartRefCookie",
                table: "ShoppingCart");

            migrationBuilder.AlterColumn<Guid>(
                name: "IngredientId",
                table: "ShoppingCartItem",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "IngredientId",
                table: "RecipeItem",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeItem_Ingredient_IngredientId",
                table: "RecipeItem",
                column: "IngredientId",
                principalTable: "Ingredient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItem_Ingredient_IngredientId",
                table: "ShoppingCartItem",
                column: "IngredientId",
                principalTable: "Ingredient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
