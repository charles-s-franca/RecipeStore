using RecipeStoreViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeStore.Services.Message
{
    public class AddRecipeRequest
    {
        public NewRecipeViewModel model { get; set; }
    }
}
