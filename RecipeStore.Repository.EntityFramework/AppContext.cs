using Microsoft.EntityFrameworkCore;
using RecipeStore.Entity;
using RecipeStore.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeStore.Repository.EntityFramework
{
    public class AppContext : DbContext, IAppContext
    {
        public AppContext()
            : base()
        { }

        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItem { get; set; }
        public DbSet<RecipeItem> RecipeItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppConfiguration.GetConnectionString());
        }
    }
}
