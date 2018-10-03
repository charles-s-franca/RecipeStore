using RecipeStoreViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeStore.Services.Message
{
    public class GetShoppingCartsResponse
    {
        public IEnumerable<ShoppingCartViewModel> list { get; internal set; }
    }
}
