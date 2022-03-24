using Cookbook.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook.ViewModels
{
    internal class RecipeItemViewModel : BaseViewModel
    {
        //private string _title;
        //private string _shortDescription;
        //private string _thumbnailImage;
        private readonly Recipe _recipe;
        public RecipeItemViewModel(Recipe recipe)
        {
            _recipe = recipe;   
            Name = recipe.Name;
            ShortDescription = recipe.ShortDescription;
            ThumbnailImage = recipe.ThumbnailImage;
        }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string ThumbnailImage { get; set; }


        public Recipe GetRecipe()
        {
            return _recipe;
        }
        


    }
}
