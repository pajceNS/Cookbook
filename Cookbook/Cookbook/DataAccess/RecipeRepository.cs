using Cookbook.Models;
using Cookbook.ViewModels;
using Cookbook.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using Xamarin.Essentials;

namespace Cookbook.DataAccess
{
    internal class RecipeRepository : IRecipeRepository
    {
        //jsonconvert.deserializeObject<RecipeList>("recipe.json content");
        private List<Recipe> _recipes = new List<Recipe>();
        private const string FileName = "Cookbook.Resources.recipe.json";
        public RecipeRepository()
        {
            LoadRecipes();
        }
        public IEnumerable<Recipe> GetAllRecipes()
        {
            return _recipes.ToList();
        }
        private async void LoadRecipes()
        {
            var assembly = typeof(RecipeRepository).Assembly;
            var file = assembly.GetManifestResourceStream(FileName);

                using (var reader = new StreamReader(file))
                {
                    var fileContents = await reader.ReadToEndAsync();
                    var listRecipes = JsonConvert.DeserializeObject<Models.RecipeList>(fileContents);
                    _recipes = listRecipes.Recipe;
                }
        }
        
        //private void Save()
        //{
        //    File.WriteAllText(Path.Combine(FileSystem.AppDataDirectory, FileName), JsonConvert.SerializeObject(_recipes));
        //}

        //public void AddRecipe(Recipe recipe)
        //{
        //    _recipes.Add(recipe);
        //    Save();
        //}

        //public void DeleteRecipe(Guid id)
        //{
        //    _recipes = _recipes.Where(n => n.Id != id).ToList();
        //    Save();
        //}
        public List<Recipe> GetRecipesForType(string mealName)
        {
            // load from json
            //filter by type
            //return List of recipes
            //var recipes = GetAllRecipes();            
           var recipeToDisplay = _recipes.Where(i => i.Type == mealName).ToList();
           return recipeToDisplay;
        }

        public ObservableCollection<MainButtonViewModel> GetUniqueTypesOfFood()
        {
           var UniqueTypeRecipesTemporary = _recipes
                .GroupBy(p => p.Type)
                .Select(g => g.First())
                .Select(r => new MainButtonViewModel(r))
                .ToList();
            var UniqueTypeRecipes = new ObservableCollection<MainButtonViewModel>(UniqueTypeRecipesTemporary);
            
            return UniqueTypeRecipes;
        }
        public List<Recipe> GetRecipeForId(Guid id)
        {
            var recipeToDisplay = _recipes.Where(i => i.Id == id).ToList();
            return recipeToDisplay;
        }
    }
}
