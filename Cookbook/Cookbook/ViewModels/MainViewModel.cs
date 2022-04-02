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
        private MainButtonViewModel _selectedRecipe;

        private ObservableCollection<MainButtonViewModel> _uniqueTypeRecipes;
        public MainViewModel(INavigationService navigationService, IRecipeRepository recipeRepository)
        {
            _navigationService = navigationService;
            _recipeRepository = recipeRepository;

            UniqueTypeRecipes = recipeRepository.GetUniqueTypesOfFood();   
            ButtonSettings = new Command(OnButtonSettings);
            SelectedMealTypeCommand = new Command(OnSelectedMealTypeCommand);
        }
        public ICommand ButtonSettings { get; }
        public ICommand SelectedMealTypeCommand { get; }
        public MainButtonViewModel SelectedRecipe
        {
            get
            {
                return _selectedRecipe;
            }
            set
            {
                _selectedRecipe = value;
                OnPropertyChanged(nameof(SelectedRecipe));
            }
        }
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
        
        private void OnSelectedMealTypeCommand()
        {


            if (SelectedRecipe != null)
            {
                _navigationService.NavigateToRecipeListViewModel(SelectedRecipe.Type);
            }
        }
    }
}
