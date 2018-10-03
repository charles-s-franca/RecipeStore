using RecipeStore.Services.Message;

namespace RecipeStore.Services.Interfaces
{
    public interface IIngredientService
    {
        GetIngredientsResponse GetIngredients(GetIngredientsRequest request);
        AddIngredientResponse AddIngredients(AddIngredientRequest request);
    }
}