using RecipeStoreViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeStoreViewModel
{
    public class NewRecipeItemViewModel
    {
        public Guid IngredientId { get; set; }
        public MeasureViewModel Measure { get; set; }
        public double Quantity { get; set; }
    }
}
