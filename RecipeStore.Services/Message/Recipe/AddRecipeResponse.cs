using RecipeStoreViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeStore.Services.Message
{
    public class AddRecipeResponse
    {
        public RecipeViewModel recipe { get; internal set; }
    }
}
