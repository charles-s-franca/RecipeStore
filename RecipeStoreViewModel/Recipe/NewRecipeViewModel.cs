using RecipeStoreViewModel;
using System;
using System.Collections.Generic;

namespace RecipeStoreViewModel
{
    public class NewRecipeViewModel
    {
        public string Title { get; set; }
        public IEnumerable<NewRecipeItemViewModel> Ingredients { get; set; }
    }
}
