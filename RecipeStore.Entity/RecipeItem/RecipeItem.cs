using RecipeStore.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeStore.Entity
{
    public class RecipeItem : BaseModel<Guid>
    {
        public Ingredient Ingredient { get; set; }
        public Guid IngredientId { get; set; }
        public Measure Measure { get; set; }
        public double Quantity { get; set; }

        public override bool validate()
        {
            return true;
        }
    }
}
