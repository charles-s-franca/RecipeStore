using RecipeStore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeStore.Repository.EntityFramework.Implementation
{
    public class IngredientRepository : BaseRepository<Ingredient, Guid>, IIngredientRepsitory
    {
        public IngredientRepository(IUnitOfWork unit) : base(unit)
        {

        }
    }
}
