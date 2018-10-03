using RecipeStoreViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeStore.Services.Message
{
    public class AddShoppingCartRequest
    {
        public NewShoppingCartViewModel model { get; set; }
    }
}
