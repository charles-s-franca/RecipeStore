using RecipeStore.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeStore.Entity
{
    public class ShoppingCart : BaseModel<Guid>
    {
        public string CartRefCookie { get; set; }
        public virtual IEnumerable<ShoppingCartItem> ShoppingCartItems { get; set; }

        public override bool validate()
        {
            return true;
        }
    }
}
