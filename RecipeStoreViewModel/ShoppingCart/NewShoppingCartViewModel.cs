using RecipeStoreViewModel;
using System;
using System.Collections.Generic;

namespace RecipeStoreViewModel
{
    public class NewShoppingCartViewModel
    {
        public string CartRefCookie { get; set; }
        public IEnumerable<Guid> Recipes { get; set; }
    }
}
