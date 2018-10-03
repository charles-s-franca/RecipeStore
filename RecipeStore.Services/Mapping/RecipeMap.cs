using RecipeStore.Entity;
using RecipeStoreViewModel;
using System.Collections.Generic;
using System.Linq;

namespace RecipeStore.Services.Mapping
{
    public static class RecipeMap
    {
        public static RecipeViewModel ToRecipeViewModel(this Recipe entity)
        {
            return AutoMapper.Mapper.Map<Recipe, RecipeViewModel>(entity);
        }

        public static IEnumerable<RecipeViewModel> ToRecipeViewModel(this IEnumerable<Recipe> entity)
        {
            return AutoMapper.Mapper.Map<IEnumerable<Recipe>, IEnumerable<RecipeViewModel>>(entity.ToList());
        }
    }
}
