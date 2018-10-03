using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RecipeStore.Services.Message
{
    public class GetShoppingCartsRequest
    {
        public Expression<Func<Entity.ShoppingCart, bool>> filter { get; set; }
        public Func<IQueryable<Entity.ShoppingCart>, IOrderedQueryable<Entity.ShoppingCart>> orderBy { get; set; }
    }
}
