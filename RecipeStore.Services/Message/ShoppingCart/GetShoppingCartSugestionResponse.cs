using RecipeStoreViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeStore.Services.Message
{
    public class GetShoppingCartSugestionResponse
    {
        public ShoppingCartViewModel cart { get; internal set; }
    }
}
