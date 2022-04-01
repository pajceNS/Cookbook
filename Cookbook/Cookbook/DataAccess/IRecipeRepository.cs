using Cookbook.Models;
using System;
using System.Collections.Generic;

namespace Cookbook.DataAccess
{
    internal interface IRecipeRepository
    {
        //void AddRecipe(Recipe recipe);
        //void DeleteRecipe(Guid id);
        IEnumerable<Recipe> GetAllRecipes();
        List<Recipe> GetRecipesForType(string mealName);
        List<Recipe> GetRecipeForId(Guid id);
    }
}