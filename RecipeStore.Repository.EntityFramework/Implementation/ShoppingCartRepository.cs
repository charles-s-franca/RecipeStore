using RecipeStore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeStore.Repository.EntityFramework.Implementation
{
    public class ShoppingCartRepository : BaseRepository<ShoppingCart, Guid>, IShoppingCartRepository
    {
        public ShoppingCartRepository(IUnitOfWork unit) : base(unit)
        {

        }
    }
}
