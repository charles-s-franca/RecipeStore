using RecipeStoreViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeStore.Services.Message
{
    public class GetIngredientsResponse
    {
        public IEnumerable<IngredientViewModel> list { get; internal set; }
    }
}
