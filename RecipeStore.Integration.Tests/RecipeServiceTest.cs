using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeStore.Services.Interfaces;
using RecipeStore.Services.Message;
using RecipeStoreViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeStore.Integration.Tests
{
    [TestClass]
    public class RecipeServiceTest
    {
        public IRecipeService _recipeService { get; set; }
        [TestInitialize]
        public void Init()
        {
            StructureMapSetup.Config();
            Services.AutomapperSetup.Config();
            _recipeService = StructureMapSetup.Container.GetInstance<IRecipeService>();
        }

        [TestMethod]
        public void Should_Add_A_Recipe_Wit_Items_Successfully()
        {
            var recipe = new NewRecipeViewModel();
            recipe.Title = "Integration Recipe";

            var ingredients = new List<NewRecipeItemViewModel>()
            {
                new NewRecipeItemViewModel(){
                    IngredientId = Guid.Parse("FB1BCEE5-B3F2-443A-B14D-511C52C959EA"),
                    Measure = MeasureViewModel.TSP,
                    Quantity = 0.5
                }
            };
            recipe.Ingredients = ingredients.AsEnumerable();
            
            var request = new AddRecipeRequest() { model = recipe };
            var response = _recipeService.AddRecipes(request);
        }
    }
}
