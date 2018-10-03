using Microsoft.AspNetCore.Mvc;
using RecipeStore.Domain;
using RecipeStore.Services.Interfaces;
using RecipeStoreViewModel;
using System;
using System.Collections.Generic;
using System.Net;

namespace RecipeStore.Controllers
{
    [Produces("application/json")]
    [Route("api/recipe")]
    public class RecipeController : Controller
    {
        IRecipeService _recipeService;

        public RecipeController(
            IRecipeService recipeService
        )
        {
            _recipeService = recipeService;
        }

        [HttpGet("")]
        public ApiResponse<IEnumerable<RecipeViewModel>> GetRecipes()
        {
            try
            {
                return ApiResponse<IEnumerable<RecipeViewModel>>.CreateResponse(true, "", _recipeService.GetRecipes(new Services.Message.GetRecipesRequest()).list);
            }
            catch (BusinessRuleException ex)
            {
                return ApiResponse<IEnumerable<RecipeViewModel>>.CreateResponse(false, ex.Message, null, rules: ex.brokenRules, code: HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return ApiResponse<IEnumerable<RecipeViewModel>>.CreateResponse(false, "An unexpected error occured.", null, code: HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost("")]
        public ApiResponse<RecipeViewModel> AddRecipe([FromBody] NewRecipeViewModel model)
        {
            try
            {
                return ApiResponse<RecipeViewModel>.CreateResponse(true, "", _recipeService.AddRecipes(new Services.Message.AddRecipeRequest() { model = model }).recipe);
            }
            catch (BusinessRuleException ex)
            {
                return ApiResponse<RecipeViewModel>.CreateResponse(false, ex.Message, null, rules: ex.brokenRules, code: HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return ApiResponse<RecipeViewModel>.CreateResponse(false, "An unexpected error occured.", null, code: HttpStatusCode.InternalServerError);
            }
        }
    }
}