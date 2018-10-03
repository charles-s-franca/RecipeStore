using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeStore.Entity;
using RecipeStore.Repository.EntityFramework.Implementation;
using System.Linq;

namespace RecipeStore.Repository.EntityFramework.Tests
{
    [TestClass]
    public class RecipeTests
    {
        public AppContext _appContext { get; set; }
        public IUnitOfWork _unitOfWork { get; set; }
        public IRecipeRepository _recipeRepository { get; set; }

        [TestInitialize]
        public void Init()
        {
            _appContext = new AppContext();
            _unitOfWork = new UnitOfWork(_appContext);
            _recipeRepository = new RecipeRepository(_unitOfWork);
        }

        [TestMethod]
        public void InsertRecipe()
        {
            var recipe = new Recipe();
            recipe.Title = "My Recipe";
            _recipeRepository.Insert(recipe);

            _unitOfWork.Commit();
        }

        [TestMethod]
        public void UpdateRecipe()
        {
            var recipe = _recipeRepository.GetAll().FirstOrDefault();
            recipe.Title = "Updated title";
            _recipeRepository.Update(recipe);

            _unitOfWork.Commit();
        }

        [TestMethod]
        public void DeleteRecipe()
        {
            var recipe = _recipeRepository.GetAll().FirstOrDefault();
            _recipeRepository.Delete(recipe);

            _unitOfWork.Commit();
        }
    }
}
