using RecipeStore.Entity;
using RecipeStoreViewModel;
using System.Collections.Generic;
using System.Linq;

namespace RecipeStore.Services.Mapping
{
    public static class IngredientMap
    {
        public static IngredientViewModel ToIngredientViewModel(this Ingredient entity)
        {
            return AutoMapper.Mapper.Map<Ingredient, IngredientViewModel>(entity);
        }

        public static IEnumerable<IngredientViewModel> ToIngredientViewModel(this IEnumerable<Ingredient> entity)
        {
            return AutoMapper.Mapper.Map<IEnumerable<Ingredient>, IEnumerable<IngredientViewModel>>(entity.ToList());
        }
    }
}
