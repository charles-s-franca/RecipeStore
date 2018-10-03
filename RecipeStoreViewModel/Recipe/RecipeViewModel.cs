using RecipeStoreViewModel;
using System;
using System.Collections.Generic;

namespace RecipeStoreViewModel
{
    public class RecipeViewModel
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<RecipeItemViewModel> Ingredients { get; set; }
    }
}
