using RecipeStore.Domain;
using RecipeStore.Entity;
using RecipeStore.Repository.EntityFramework;
using RecipeStore.Services.Interfaces;
using RecipeStore.Services.Mapping;
using RecipeStore.Services.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RecipeStore.Services.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public IShoppingCartRepository _shoppingCartRepository { get; set; }
        public IIngredientRepsitory _ingredientRepository { get; set; }
        public IRecipeRepository _recipeRepository { get; set; }

        public ShoppingCartService(
            IUnitOfWork unitOfWork,
            IShoppingCartRepository shoppingCartRepository,
            IIngredientRepsitory ingredientRepository,
            IRecipeRepository recipeRepository
            )
        {
            _unitOfWork = unitOfWork;
            _shoppingCartRepository = shoppingCartRepository;
            _ingredientRepository = ingredientRepository;
            _recipeRepository = recipeRepository;
        }

        public AddShoppingCartResponse AddShoppingCarts(AddShoppingCartRequest request)
        {
            var response = new AddShoppingCartResponse();
            var cart = new ShoppingCart
            {
                CartRefCookie = request.model.CartRefCookie
            };

            if (request.model.Recipes != null && request.model.Recipes.Count() > 0)
            {
                var soppingCartItems = GetRecipeItemsSum(request.filter, request.model.Recipes.ToList());
                cart.ShoppingCartItems = soppingCartItems.AsEnumerable();
            }

            if (!cart.isValid())
                throw new BusinessRuleException("There was some errors", cart.getBrokedRules());

            _shoppingCartRepository.Insert(cart);
            _unitOfWork.Commit();

            response.cart = cart.ToShoppingCartViewModel();
            return response;
        }

        public GetShoppingCartsResponse GetShoppingCart(GetShoppingCartsRequest request)
        {
            var response = new GetShoppingCartsResponse();
            response.list = _shoppingCartRepository
                                .GetAll(request.filter, request.orderBy, "ShoppingCartItems", "ShoppingCartItems.Ingredient")
                                .ToShoppingCartViewModel();
            return response;
        }

        public GetShoppingCartSugestionResponse GetShoppingCartSugestion(GetShoppingCartSugestionRequest request)
        {
            var response = new GetShoppingCartSugestionResponse();
            var soppingCartItems = GetRecipeItemsSum(request.filter, request.model.Recipes.ToList());

            var cart = new ShoppingCart()
            {
                ShoppingCartItems = soppingCartItems.AsEnumerable()
            };

            response.cart = cart.ToShoppingCartViewModel();
            return response;
        }

        private List<ShoppingCartItem> GetRecipeItemsSum(Expression<Func<Entity.Recipe, bool>> filter, List<Guid> Recipes)
        {
            var recipesIds = Recipes.ToArray();
            var recipes = _recipeRepository.GetAll(filter, null, "Ingredients", "Ingredients.Ingredient");

            var ingredients = new List<RecipeItem>();
            foreach (var recipe in recipes)
            {
                ingredients.AddRange(recipe.Ingredients);
            }

            List<ShoppingCartItem> soppingCartItems = ingredients
                                        .GroupBy(i => new { i.Ingredient.Id, i.Measure })
                                        .Select(i => new ShoppingCartItem
                                        {
                                            Ingredient = i.FirstOrDefault().Ingredient,
                                            Quantity = i.Sum(item => item.Quantity),
                                            IngredientId = i.FirstOrDefault().IngredientId,
                                            Measure = i.FirstOrDefault().Measure
                                        })
                                        .ToList();

            return soppingCartItems;
        }
    }
}
