using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeStore.Services.Message
{
    public class AddShoppingCartResponse
    {
        public RecipeStoreViewModel.ShoppingCartViewModel cart { get; set; }
    }
}
