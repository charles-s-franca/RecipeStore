using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RecipeStore.Entity;
using RecipeStore.Repository.EntityFramework;
using RecipeStore.Services.Implementation;
using RecipeStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeStore.Services.Tests
{
    [TestClass]
    public class ShoppingCartServiceTest
    {
        public Mock<IUnitOfWork> _unitOfWork { get; set; }
        public Mock<IRecipeRepository> _recipeRepository { get; set; }
        public Mock<IIngredientRepsitory> _ingredientRepository { get; set; }
        public Mock<IShoppingCartRepository> _shoppingCartRepository { get; set; }
        public IShoppingCartService _shoppingCartService { get; set; }

        [TestInitialize]
        public void Init()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _recipeRepository = new Mock<IRecipeRepository>();
            _ingredientRepository = new Mock<IIngredientRepsitory>();
            _shoppingCartRepository = new Mock<IShoppingCartRepository>();

            _shoppingCartService = new ShoppingCartService(
                _unitOfWork.Object,
                _shoppingCartRepository.Object,
                _ingredientRepository.Object,
                _recipeRepository.Object
            );

            AutomapperSetup.Config();
        }

        [TestMethod]
        public void Shold_Get_A_Somed_ShoppingCart_Suggestion()
        {
            var recipes = MakeTestRecipes();
            var recipiesIds = new List<Guid> { Guid.Parse("FB1BCEE5-B3F2-443A-B14D-511C52C959EA"), Guid.Parse("DE90B88D-42C6-402F-91F3-489E400727C1") };

            _recipeRepository.Setup(r => r.GetAll(rec => recipiesIds.Contains(rec.Id), null, "ShoppingCartItems", "ShoppingCartItems.Ingredient")).Returns(recipes);

            var model = new RecipeStoreViewModel.NewShoppingCartViewModel() {};
            model.Recipes = recipiesIds;

            var request = new Message.GetShoppingCartSugestionRequest()
            {
                model = model,
                filter = rec => recipiesIds.Contains(rec.Id)
            };

            var response = _shoppingCartService.GetShoppingCartSugestion(request);

            Assert.AreEqual(3, response.cart.ShoppingCartItems.Count());
            Assert.AreEqual(1, response.cart.ShoppingCartItems.FirstOrDefault().Quantity);
            Assert.AreEqual(4, response.cart.ShoppingCartItems.ToArray()[1].Quantity);
            Assert.AreEqual(3, response.cart.ShoppingCartItems.ToArray()[2].Quantity);
        }

        public List<Recipe> MakeTestRecipes ()
        {
            var recipes = new List<Recipe>()
            {
                new Recipe() {
                    Id = Guid.Parse("DE90B88D-42C6-402F-91F3-489E400727C1"),
                    Title = "First Recipe",
                    Ingredients = new List<RecipeItem>()
                    {
                        new RecipeItem
                        {
                            IngredientId = Guid.Parse("DE90B88D-42C6-402F-91F3-489E400727C1"),
                            Ingredient = new Ingredient
                            {
                                Id = Guid.Parse("DE90B88D-42C6-402F-91F3-489E400727C1"),
                                Name = "Ingredient 1"
                            },
                            Measure = Measure.TSP,
                            Quantity = 0.5
                        },
                        new RecipeItem
                        {
                            IngredientId = Guid.Parse("FB1BCEE5-B3F2-443A-B14D-511C52C959EA"),
                            Ingredient = new Ingredient
                            {
                                Id = Guid.Parse("FB1BCEE5-B3F2-443A-B14D-511C52C959EA"),
                                Name = "Ingredient 2"
                            },
                            Measure = Measure.TBSP,
                            Quantity = 1
                        }
                    }
                },

                new Recipe() {
                    Id = Guid.Parse("FB1BCEE5-B3F2-443A-B14D-511C52C959EA"),
                    Title = "Second Recipe",
                    Ingredients = new List<RecipeItem>()
                    {
                        new RecipeItem
                        {
                            IngredientId = Guid.Parse("DE90B88D-42C6-402F-91F3-489E400727C1"),
                            Ingredient = new Ingredient
                            {
                                Id = Guid.Parse("DE90B88D-42C6-402F-91F3-489E400727C1"),
                                Name = "Ingredient 1"
                            },
                            Measure = Measure.TSP,
                            Quantity = 0.5
                        },
                        new RecipeItem
                        {
                            IngredientId = Guid.Parse("FB1BCEE5-B3F2-443A-B14D-511C52C959EA"),
                            Ingredient = new Ingredient
                            {
                                Id = Guid.Parse("FB1BCEE5-B3F2-443A-B14D-511C52C959EA"),
                                Name = "Ingredient 2"
                            },
                            Measure = Measure.TBSP,
                            Quantity = 3
                        },
                        new RecipeItem
                        {
                            IngredientId = Guid.Parse("D8268962-8D42-4E35-B9F6-CDF2D4C945A8"),
                            Ingredient = new Ingredient
                            {
                                Id = Guid.Parse("D8268962-8D42-4E35-B9F6-CDF2D4C945A8"),
                                Name = "Ingredient 3"
                            },
                            Measure = Measure.TBSP,
                            Quantity = 3
                        }
                    }
                }
            };

            return recipes;
        }
    }
}
