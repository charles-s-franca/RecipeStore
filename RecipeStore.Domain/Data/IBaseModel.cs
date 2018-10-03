using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeStore.Domain.Data
{
    public interface IBaseModel
    {
        DateTime createdAt { get; set; }
        DateTime updatedAt { get; set; }
    }
}
