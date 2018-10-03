using RecipeStoreViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeStore.Services.Message
{
    public class GetReciepesResponse
    {
        public IEnumerable<RecipeViewModel> list { get; internal set; }
    }
}
