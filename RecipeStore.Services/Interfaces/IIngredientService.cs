using RecipeStore.Services.Message;

namespace RecipeStore.Services.Interfaces
{
    public interface IIngredinetService
    {
        GetIngredientsResponse GetIngredients(GetIngredientsRequest request);
        AddIngredientResponse AddIngredients(AddIngredientRequest request);
    }
}