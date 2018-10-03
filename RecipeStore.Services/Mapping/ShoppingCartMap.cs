using RecipeStore.Entity;
using RecipeStoreViewModel;
using System.Collections.Generic;
using System.Linq;

namespace RecipeStore.Services.Mapping
{
    public static class ShoppingCartMap
    {
        public static ShoppingCartViewModel ToShoppingCartViewModel(this ShoppingCart entity)
        {
            return AutoMapper.Mapper.Map<ShoppingCart, ShoppingCartViewModel>(entity);
        }

        public static IEnumerable<ShoppingCartViewModel> ToShoppingCartViewModel(this IEnumerable<ShoppingCart> entity)
        {
            return AutoMapper.Mapper.Map<IEnumerable<ShoppingCart>, IEnumerable<ShoppingCartViewModel>>(entity.ToList());
        }
    }
}
