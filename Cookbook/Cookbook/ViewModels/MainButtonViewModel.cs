using Cookbook.DataAccess;
using Cookbook.Models;
using Cookbook.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cookbook.ViewModels
{
    internal class MainButtonViewModel : BaseViewModel
    {
        private string _type;
        private readonly INavigationService _navigationService;

        public MainButtonViewModel(Recipe recipe)
        {
            Type = recipe.Type;
        }
        public MainButtonViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            MealButton = new Command<string>(OnMealButton);
        }
        public ICommand MealButton { get; }

        public string Type
        {
            get => _type;
            set 
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }
        private void OnMealButton(string mealName)
        {
            _navigationService.NavigateToRecipeListViewModel(mealName);
        }
    }
}
