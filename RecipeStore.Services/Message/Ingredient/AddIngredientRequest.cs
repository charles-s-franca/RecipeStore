using RecipeStoreViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeStore.Services.Message
{
    public class AddIngredientRequest
    {
        public NewIngredientViewModel model { get; set; }
    }
}
