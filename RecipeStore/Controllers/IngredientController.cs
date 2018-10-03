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
    [Route("api/ingredient")]
    public class IngredientController : Controller
    {
        IIngredientService _ingredientService;

        public IngredientController(
            IIngredientService ingredientService
        )
        {
            _ingredientService = ingredientService;
        }

        [HttpGet("")]
        public ApiResponse<IEnumerable<IngredientViewModel>> GetRecipes()
        {
            try
            {
                return ApiResponse<IEnumerable<IngredientViewModel>>.CreateResponse(true, "", _ingredientService.GetIngredients(new Services.Message.GetIngredientsRequest()).list);
            }
            catch (BusinessRuleException ex)
            {
                return ApiResponse<IEnumerable<IngredientViewModel>>.CreateResponse(false, ex.Message, null, rules: ex.brokenRules, code: HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return ApiResponse<IEnumerable<IngredientViewModel>>.CreateResponse(false, "An unexpected error occured.", null, code: HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost("")]
        public ApiResponse<IngredientViewModel> AddRecipe([FromBody] NewIngredientViewModel model)
        {
            try
            {
                return ApiResponse<IngredientViewModel>.CreateResponse(true, "", _ingredientService.AddIngredients(new Services.Message.AddIngredientRequest() { model = model }).ingredient);
            }
            catch (BusinessRuleException ex)
            {
                return ApiResponse<IngredientViewModel>.CreateResponse(false, ex.Message, null, rules: ex.brokenRules, code: HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return ApiResponse<IngredientViewModel>.CreateResponse(false, "An unexpected error occured.", null, code: HttpStatusCode.InternalServerError);
            }
        }
    }
}