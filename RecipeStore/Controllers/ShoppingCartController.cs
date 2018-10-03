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
    [Route("api/cart")]
    public class ShoppingCartController : Controller
    {
        IShoppingCartService _shoppingCartService;

        public ShoppingCartController(
            IShoppingCartService shoppingCartService
        )
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet("")]
        public ApiResponse<IEnumerable<ShoppingCartViewModel>> GetRecipes()
        {
            try
            {
                return ApiResponse<IEnumerable<ShoppingCartViewModel>>.CreateResponse(true, "", _shoppingCartService.GetShoppingCart(new Services.Message.GetShoppingCartsRequest()).list);
            }
            catch (BusinessRuleException ex)
            {
                return ApiResponse<IEnumerable<ShoppingCartViewModel>>.CreateResponse(false, ex.Message, null, rules: ex.brokenRules, code: HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return ApiResponse<IEnumerable<ShoppingCartViewModel>>.CreateResponse(false, "An unexpected error occured.", null, code: HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost("")]
        public ApiResponse<ShoppingCartViewModel> AddRecipe([FromBody] NewShoppingCartViewModel model)
        {
            try
            {
                return ApiResponse<ShoppingCartViewModel>.CreateResponse(true, "", _shoppingCartService.AddShoppingCarts(new Services.Message.AddShoppingCartRequest() { model = model }).cart);
            }
            catch (BusinessRuleException ex)
            {
                return ApiResponse<ShoppingCartViewModel>.CreateResponse(false, ex.Message, null, rules: ex.brokenRules, code: HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return ApiResponse<ShoppingCartViewModel>.CreateResponse(false, "An unexpected error occured.", null, code: HttpStatusCode.InternalServerError);
            }
        }
    }
}