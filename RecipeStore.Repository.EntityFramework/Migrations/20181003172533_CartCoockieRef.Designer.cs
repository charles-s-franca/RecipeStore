﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using RecipeStore.Entity;
using RecipeStore.Repository.EntityFramework;
using System;

namespace RecipeStore.Repository.EntityFramework.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20181003172533_CartCoockieRef")]
    partial class CartCoockieRef
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RecipeStore.Entity.Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<DateTime>("createdAt");

                    b.Property<DateTime>("updatedAt");

                    b.HasKey("Id");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("RecipeStore.Entity.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.Property<DateTime>("createdAt");

                    b.Property<DateTime>("updatedAt");

                    b.HasKey("Id");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("RecipeStore.Entity.RecipeItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("IngredientId");

                    b.Property<int>("Measure");

                    b.Property<double>("Quantity");

                    b.Property<Guid?>("RecipeId");

                    b.Property<DateTime>("createdAt");

                    b.Property<DateTime>("updatedAt");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeItem");
                });

            modelBuilder.Entity("RecipeStore.Entity.ShoppingCart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CartRefCookie");

                    b.Property<DateTime>("createdAt");

                    b.Property<DateTime>("updatedAt");

                    b.HasKey("Id");

                    b.ToTable("ShoppingCart");
                });

            modelBuilder.Entity("RecipeStore.Entity.ShoppingCartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("IngredientId");

                    b.Property<int>("Measure");

                    b.Property<double>("Quantity");

                    b.Property<Guid?>("ShoppingCartId");

                    b.Property<DateTime>("createdAt");

                    b.Property<DateTime>("updatedAt");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("ShoppingCartItem");
                });

            modelBuilder.Entity("RecipeStore.Entity.RecipeItem", b =>
                {
                    b.HasOne("RecipeStore.Entity.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RecipeStore.Entity.Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId");
                });

            modelBuilder.Entity("RecipeStore.Entity.ShoppingCartItem", b =>
                {
                    b.HasOne("RecipeStore.Entity.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RecipeStore.Entity.ShoppingCart")
                        .WithMany("ShoppingCartItems")
                        .HasForeignKey("ShoppingCartId");
                });
#pragma warning restore 612, 618
        }
    }
}
