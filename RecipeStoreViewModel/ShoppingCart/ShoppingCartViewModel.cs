using RecipeStoreViewModel;
using System;
using System.Collections.Generic;

namespace RecipeStoreViewModel
{
    public class ShoppingCartViewModel
    {
        public Guid? Id { get; set; }
        public IEnumerable<RecipeItemViewModel> Ingredients { get; set; }
    }
}
