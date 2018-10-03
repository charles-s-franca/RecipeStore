using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RecipeStore.Services.Message
{
    public class GetRecipesRequest
    {
        public Expression<Func<Entity.Recipe, bool>> filter { get; set; }
        public Func<IQueryable<Entity.Recipe>, IOrderedQueryable<Entity.Recipe>> orderBy { get; set; }
    }
}
