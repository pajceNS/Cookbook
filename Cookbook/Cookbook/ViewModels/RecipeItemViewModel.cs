using Cookbook.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook.ViewModels
{
    internal class RecipeItemViewModel : BaseViewModel
    {
        private string _name;
        private string _shortDescription;
        private string _thumbnailImage;
        private readonly Recipe _recipe;
        public RecipeItemViewModel(Recipe recipe)
        {
            _recipe = recipe;   
            Name = recipe.Name;
            ShortDescription = recipe.ShortDescription;
            ThumbnailImage = recipe.ThumbnailImage;
        }
        public Recipe Recipe { get; }
        public string Name 
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            } 
        }
        public string ShortDescription 
        {
            get => _shortDescription;
            set
            {
                _shortDescription = value;
                OnPropertyChanged(nameof(ShortDescription));
            }
        }
        public string ThumbnailImage 
        {
            get => _thumbnailImage;
            set
            {
                _thumbnailImage = value;
                OnPropertyChanged(nameof(ThumbnailImage));
            }
        }

        
        public Recipe GetRecipe()
        {
            return _recipe;
        }
        


    }
}
