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
    public class RecipeService : IRecipeService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public IRecipeRepository _recipeRepository { get; set; }
        public IIngredientRepsitory _ingredientRepository { get; set; }

        public RecipeService(
            IUnitOfWork unitOfWork,
            IRecipeRepository recipeRepository,
            IIngredientRepsitory ingredientRepository
            )
        {
            _unitOfWork = unitOfWork;
            _recipeRepository = recipeRepository;
            _ingredientRepository = ingredientRepository;
        }

        public AddRecipeResponse AddRecipes(AddRecipeRequest request)
        {
            var response = new AddRecipeResponse();
            var recipe = new Recipe
            {
                Title = request.model.Title
            };
            if (request.model.Ingredients != null && request.model.Ingredients.Count() > 0)
            {
                var items = new List<RecipeItem>();
                foreach (var item in request.model.Ingredients)
                {
                    var newItem = new RecipeItem
                    {
                        IngredientId = item.IngredientId,
                        Measure = (Measure)item.Measure,
                        Quantity = item.Quantity
                    };
                    items.Add(newItem);
                }
                recipe.Ingredients = items.AsEnumerable();
            }

            if (!recipe.isValid())
                throw new BusinessRuleException("There was some errors", recipe.getBrokedRules());

            _recipeRepository.Insert(recipe);
            _unitOfWork.Commit();

            response.recipe = recipe.ToRecipeViewModel();
            return response;
        }

        public GetReciepesResponse GetRecipes(GetRecipesRequest request)
        {
            var response = new GetReciepesResponse();
            response.list = _recipeRepository
                                .GetAll(request.filter, request.orderBy, "Ingredients", "Ingredients.Ingredient")
                                .ToRecipeViewModel();

            return response;
        }
    }
}
