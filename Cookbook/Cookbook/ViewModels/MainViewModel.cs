using Cookbook.DataAccess;
using Cookbook.Models;
using Cookbook.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cookbook.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly INavigationService _navigationService;

        private ObservableCollection<MainButtonViewModel> _uniqueTypeRecipes;
        public MainViewModel(INavigationService navigationService, IRecipeRepository recipeRepository)
        {
            _navigationService = navigationService;
            _recipeRepository = recipeRepository;

            UniqueTypeRecipes = recipeRepository.GetUniqueTypesOfFood();   
            ButtonSettings = new Command(OnButtonSettings);
            MealButton = new Command<string>(OnMealButton);
        }
        public ICommand ButtonSettings { get; }
        public ICommand MealButton { get; }
        
        public ObservableCollection<MainButtonViewModel> UniqueTypeRecipes
        {
            get
            {
                return _uniqueTypeRecipes;
            }
            set
            {
                _uniqueTypeRecipes = value;
                OnPropertyChanged(nameof(UniqueTypeRecipes));
            }
        }

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
