using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RecipeStore.Services.Message
{
    public class GetIngredientsRequest
    {
        public Expression<Func<Entity.Ingredient, bool>> filter { get; set; }
        public Func<IQueryable<Entity.Ingredient>, IOrderedQueryable<Entity.Ingredient>> orderBy { get; set; }
    }
}
