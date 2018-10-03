using RecipeStoreViewModel;
using System;
using System.Linq.Expressions;

namespace RecipeStore.Services.Message
{
    public class GetShoppingCartSugestionRequest
    {
        public Expression<Func<Entity.Recipe, bool>> filter { get; set; }
        public NewShoppingCartViewModel model { get; set; }
    }
}
