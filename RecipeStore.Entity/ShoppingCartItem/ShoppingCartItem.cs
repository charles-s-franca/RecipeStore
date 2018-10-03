using RecipeStore.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeStore.Entity
{
    public class ShoppingCartItem : BaseModel<Guid>
    {
        public virtual Ingredient Ingredient { get; set; }
        public Guid IngredientId { get; set; }
        public Measure Measure { get; set; }
        public double Quantity { get; set; }

        public override bool validate()
        {
            return true;
        }
    }
}
