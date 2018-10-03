using RecipeStore.Entity;
using RecipeStoreViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeStore.Services
{
    public class AutomapperSetup
    {
        public static void Config()
        {
            AutoMapper.Mapper.Initialize(x =>
            {
                x.CreateMap<Recipe, RecipeViewModel>();
                x.CreateMap<RecipeItem, RecipeItemViewModel>();
                x.CreateMap<Ingredient, IngredientViewModel>();
                x.CreateMap<Measure, MeasureViewModel>();
                x.CreateMap<ShoppingCart, ShoppingCartViewModel>();
                x.CreateMap<ShoppingCartItem, ShoppingCartItemViewModel>();
            });
        }
    }
}
