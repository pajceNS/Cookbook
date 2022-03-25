using Cookbook.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook.ViewModels
{
    internal class MainItemViewModel : BaseViewModel
    {
        private string _backgroundImage;
        private readonly Recipe _recipe;
        public MainItemViewModel(Recipe recipe)
        {
            _recipe = recipe;
            BackgroundImage = recipe.BackgroundImage;
        }
        public Recipe Recipe { get; }
        public string BackgroundImage
        {
            get => _backgroundImage;
            set
            {
                _backgroundImage = value;
                OnPropertyChanged(nameof(BackgroundImage));
            }
        }
        public Recipe GetRecipe()
        {
            return _recipe;
        }
    }
}
