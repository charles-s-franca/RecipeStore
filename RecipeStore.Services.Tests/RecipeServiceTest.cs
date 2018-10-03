using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RecipeStore.Entity;
using RecipeStore.Repository.EntityFramework;
using RecipeStore.Services.Implementation;
using RecipeStore.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace RecipeStore.Services.Tests
{
    [TestClass]
    public class RecipeServiceTest
    {
        public Mock<IUnitOfWork> _unitOfWork { get; set; }
        public Mock<IRecipeRepository> _recipeRepository { get; set; }
        public Mock<IIngredientRepsitory> _ingredientRepository { get; set; }
        public IRecipeService _recipeService { get; set; }

        [TestInitialize]
        public void Init()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _recipeRepository = new Mock<IRecipeRepository>();
            _ingredientRepository = new Mock<IIngredientRepsitory>();
            _recipeService = new RecipeService(
                _unitOfWork.Object, 
                _recipeRepository.Object, 
                _ingredientRepository.Object
            );

            AutomapperSetup.Config();
        }

        [TestMethod]
        public void Shold_Get_A_Recipes_List_Successfully()
        {
            var recipes = new List<Recipe>()
            {
                new Recipe() { Title = "First Recipe" }
            };
            _recipeRepository.Setup(r => r.GetAll(null, null, "Ingredients", "Ingredients.Ingredient")).Returns(recipes);

            var response = _recipeService.GetRecipes(new Message.GetRecipesRequest());

            Assert.AreEqual(recipes.Count, response.list.ToList().Count);
            Assert.AreEqual(recipes.FirstOrDefault().Title, response.list.FirstOrDefault().Title);
        }
    }
}
