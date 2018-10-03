using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeStore.Services.Interfaces;
using RecipeStore.Services.Message;
using RecipeStoreViewModel;
using System;
using System.Collections.Generic;

namespace RecipeStore.Integration.Tests
{
    [TestClass]
    public class ShoppingCartServiceTest
    {
        public IShoppingCartService _shoppingCartService { get; set; }
        [TestInitialize]
        public void Init()
        {
            StructureMapSetup.Config();
            Services.AutomapperSetup.Config();
            _shoppingCartService = StructureMapSetup.Container.GetInstance<IShoppingCartService>();
        }

        [TestMethod]
        public void Should_Add_An_Ingredient_Successfully()
        {
            var shoppingcart = new NewShoppingCartViewModel();
            shoppingcart.CartRefCookie = "123fdfds";
            shoppingcart.Recipes = new List<Guid>()
            {
                Guid.Parse("ca505ba2-f4b5-42d8-28b6-08d62939ae3c"),
                Guid.Parse("4be82ff5-93aa-428e-28a5-08d62939f7a2"),
                Guid.Parse("2d46b9e6-8e1d-4e64-28a6-08d62939f7a2")
            };
            
            var request = new AddShoppingCartRequest() { model = shoppingcart };
            var response = _shoppingCartService.AddShoppingCarts(request);
        }
    }
}
