using RecipeStore.Entity;
using RecipeStoreViewModel;
using System.Collections.Generic;
using System.Linq;

namespace RecipeStore.Services.Mapping
{
    public static class ShoppingCartItemMap
    {
        public static ShoppingCartItemViewModel ToShoppingCartItemViewModel(this ShoppingCartItem entity)
        {
            return AutoMapper.Mapper.Map<ShoppingCartItem, ShoppingCartItemViewModel>(entity);
        }

        public static IEnumerable<ShoppingCartItemViewModel> ToShoppingCartItemViewModel(this IEnumerable<ShoppingCartItem> entity)
        {
            return AutoMapper.Mapper.Map<IEnumerable<ShoppingCartItem>, IEnumerable<ShoppingCartItemViewModel>>(entity.ToList());
        }
    }
}
