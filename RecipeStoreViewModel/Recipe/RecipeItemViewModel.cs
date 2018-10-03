using RecipeStoreViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeStoreViewModel
{
    public class RecipeItemViewModel
    {
        public IngredientViewModel Ingredient { get; set; }
        public MeasureViewModel Measure { get; set; }
        public double Quantity { get; set; }
    }
}
