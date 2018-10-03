using RecipeStore.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeStore.Entity
{
    public class Ingredient : BaseModel<Guid>
    {
        public string Name { get; set; }

        public override bool validate()
        {
            return true;
        }
    }
}
