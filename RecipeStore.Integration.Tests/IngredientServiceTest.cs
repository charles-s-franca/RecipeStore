using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeStore.Services.Interfaces;
using RecipeStore.Services.Message;
using RecipeStoreViewModel;

namespace RecipeStore.Integration.Tests
{
    [TestClass]
    public class IngredientServiceTest
    {
        public IIngredinetService _ingredientService { get; set; }
        [TestInitialize]
        public void Init()
        {
            StructureMapSetup.Config();
            Services.AutomapperSetup.Config();
            _ingredientService = StructureMapSetup.Container.GetInstance<IIngredinetService>();
        }

        [TestMethod]
        public void Should_Add_An_Ingredient_Successfully()
        {
            var ingredient = new NewIngredientViewModel();
            ingredient.Name = "Integration ingredient";
            
            var request = new AddIngredientRequest() { model = ingredient };
            var response = _ingredientService.AddIngredients(request);
        }
    }
}
