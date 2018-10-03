using RecipeStore.Domain;
using RecipeStore.Entity;
using RecipeStore.Repository.EntityFramework;
using RecipeStore.Services.Interfaces;
using RecipeStore.Services.Mapping;
using RecipeStore.Services.Message;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeStore.Services.Implementation
{
    public class IngredientService : IIngredientService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public IIngredientRepsitory _ingredientRepository { get; set; }

        public IngredientService(
            IUnitOfWork unitOfWork,
            IIngredientRepsitory ingredientRepository
            )
        {
            _unitOfWork = unitOfWork;
            _ingredientRepository = ingredientRepository;
        }

        public AddIngredientResponse AddIngredients(AddIngredientRequest request)
        {
            var response = new AddIngredientResponse();
            var ingredient = new Ingredient();
            ingredient.Name = request.model.Name;

            if (!ingredient.isValid())
                throw new BusinessRuleException("There was some errors", ingredient.getBrokedRules());

            _ingredientRepository.Insert(ingredient);
            _unitOfWork.Commit();

            response.ingredient = ingredient.ToIngredientViewModel();
            return response;
        }

        public GetIngredientsResponse GetIngredients(GetIngredientsRequest request)
        {
            var response = new GetIngredientsResponse();
            response.list = _ingredientRepository.GetAll(request.filter, request.orderBy).ToIngredientViewModel();
            return response;
        }
    }
}
