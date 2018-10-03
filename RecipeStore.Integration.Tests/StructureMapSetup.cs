﻿using RecipeStore.Entity;
using RecipeStore.Repository.EntityFramework;
using RecipeStore.Repository.EntityFramework.Implementation;
using RecipeStore.Services.Implementation;
using RecipeStore.Services.Interfaces;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeStore.Integration.Tests
{
    public class StructureMapSetup
    {
        public static Container Container { get; internal set; }
        public static void Config()
        {
            var container = new Container(_ =>
            {
                _.For<IUnitOfWork>().Use<UnitOfWork>();
                _.For<IAppContext>().Use<Repository.EntityFramework.AppContext>();
                _.For<IRecipeRepository>().Use<RecipeRepository>();
                _.For<IIngredientRepsitory>().Use<IngredientRepository>();
                _.For<IRecipeService>().Use<RecipeService>();
                _.For<IIngredinetService>().Use<IngredientService>();
            });

            StructureMapSetup.Container = container;
        }
    }
}
