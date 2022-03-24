using Cookbook.DataAccess;
using Cookbook.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cookbook.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly INavigationService _navigationService;

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            ButtonSettings = new Command(OnButtonSettings);
            MealButton = new Command<string>(OnMealButton);
        }

        

        public ICommand ButtonSettings { get; }
        public ICommand MealButton { get; }

        private void OnButtonSettings()
        {
            _navigationService.NavigateToSettingsViewModel();
        }
        private void OnMealButton(string mealName)
        {
            
            _navigationService.NavigateToRecipeListViewModel(mealName);
        }
    }
}
