using RecipeStore.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeStore.Entity
{
    public interface IIngredientRepsitory : IBaseRepository<Ingredient, Guid>
    {
    }
}
