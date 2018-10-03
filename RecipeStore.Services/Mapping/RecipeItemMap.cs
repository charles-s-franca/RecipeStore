using RecipeStore.Entity;
using RecipeStoreViewModel;
using System.Collections.Generic;
using System.Linq;

namespace RecipeStore.Services.Mapping
{
    public static class RecipeItemMap
    {
        public static RecipeItemViewModel ToRecipeItemViewModel(this RecipeItem entity)
        {
            return AutoMapper.Mapper.Map<RecipeItem, RecipeItemViewModel>(entity);
        }

        public static IEnumerable<RecipeItemViewModel> ToRecipeItemViewModel(this IEnumerable<RecipeItem> entity)
        {
            return AutoMapper.Mapper.Map<IEnumerable<RecipeItem>, IEnumerable<RecipeItemViewModel>>(entity.ToList());
        }
    }
}
