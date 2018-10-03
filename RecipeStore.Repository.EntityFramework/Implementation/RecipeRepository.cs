using RecipeStore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeStore.Repository.EntityFramework.Implementation
{
    public class RecipeRepository : BaseRepository<Recipe, Guid>, IRecipeRepository
    {
        public RecipeRepository(IUnitOfWork unit) : base(unit)
        {

        }
    }
}
