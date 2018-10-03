using RecipeStore.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeStore.Entity
{
    public class Recipe : BaseModel<Guid>
    {
        public string Title { get; set; }
        public virtual IEnumerable<RecipeItem> Ingredients { get; set; }

        public override bool validate()
        {
            return true;
        }
    }
}
