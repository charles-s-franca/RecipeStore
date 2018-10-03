using RecipeStoreViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeStore.Services.Message
{
    public class AddIngredientResponse
    {
        public IngredientViewModel ingredient { get; internal set; }
    }
}
