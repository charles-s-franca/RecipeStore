using RecipeStore.Domain;
using RecipeStore.Entity;
using RecipeStore.Repository.EntityFramework;
using RecipeStore.Services.Interfaces;
using RecipeStore.Services.Mapping;
using RecipeStore.Services.Message;
using System.Collections.Generic;
using System.Linq;

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
                var recipesIds = request.model.Recipes.ToArray();
                var recipes = _recipeRepository.GetAll("ShoppingCartItems", "ShoppingCartItems.Ingredient");

                foreach (var recipe in recipes)
                {
                    //var ingredients
                }

                //var items = new List<ShoppingCartItem>();
                //foreach (var item in request.model.Ingredients)
                //{
                //    var newItem = new ShoppingCartItem
                //    {
                //        IngredientId = item.IngredientId,
                //        Measure = (Measure)item.Measure,
                //        Quantity = item.Quantity
                //    };
                //    items.Add(newItem);
                //}
                //cart.ShoppingCartItems = items.AsEnumerable();
            }

            if (!cart.isValid())
                throw new BusinessRuleException("There was some errors", cart.getBrokedRules());

            _shoppingCartRepository.Insert(cart);
            _unitOfWork.Commit();

            //response.cart = cart.ToShoppingCartViewModel();
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
    }
}
