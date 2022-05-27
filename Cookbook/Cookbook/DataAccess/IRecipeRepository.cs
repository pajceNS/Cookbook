using Cookbook.Models;
using Cookbook.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Cookbook.DataAccess
{
    internal interface IRecipeRepository
    {
        IEnumerable<Recipe> GetAllRecipes();
        List<Recipe> GetRecipesForType(string mealName);
        List<Recipe> GetRecipeForId(Guid id);
        ObservableCollection<MainButtonViewModel> GetUniqueTypesOfFood();
    }
}