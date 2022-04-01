using Cookbook.Models;
using Cookbook.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Cookbook.DataAccess
{
    internal interface IRecipeRepository
    {
        //void AddRecipe(Recipe recipe);
        //void DeleteRecipe(Guid id);
        IEnumerable<Recipe> GetAllRecipes();
        List<Recipe> GetRecipesForType(string mealName);
        ObservableCollection<MainButtonViewModel> GetUniqueTypesOfFood ();
    }
}