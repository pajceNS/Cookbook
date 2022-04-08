using Cookbook.DataAccess;
using Cookbook.Models;
using Cookbook.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace Cookbook.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly INavigationService _navigationService;
        private MainButtonViewModel _selectedRecipe;
        private ObservableCollection<MainButtonViewModel> _uniqueTypeRecipes;
        private bool _canExecuteSettingsCommand = true;

        public MainViewModel(INavigationService navigationService, IRecipeRepository recipeRepository)
        {
            _navigationService = navigationService;
            _recipeRepository = recipeRepository;
            UniqueTypeRecipes = recipeRepository.GetUniqueTypesOfFood();
            ButtonSettings = new AsyncCommand(OnButtonSettings, () => CanExecuteSettingsCommand);
            SelectedMealTypeCommand = new AsyncCommand(OnSelectedMealTypeCommand, () => CanExecuteSettingsCommand);
        }

        public ICommand ButtonSettings { get; }
        public ICommand SelectedMealTypeCommand { get; }

        private bool CanExecuteSettingsCommand
        {
            get => _canExecuteSettingsCommand;
            set
            {
                _canExecuteSettingsCommand = value;
                ((AsyncCommand)ButtonSettings).ChangeCanExecute();
                ((AsyncCommand)SelectedMealTypeCommand).ChangeCanExecute();
            }
        }

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

        private async Task OnSelectedMealTypeCommand()
        {

            if (SelectedRecipe != null)
            {
                var mealType = SelectedRecipe.Type;                
                CanExecuteSettingsCommand = false;
                await _navigationService.NavigateToRecipeListViewModel(mealType);
                CanExecuteSettingsCommand = true;
                SelectedRecipe = null;
            }
        }

        private async Task OnButtonSettings()
        {
            CanExecuteSettingsCommand = false;
            await _navigationService.NavigateToSettingsViewModel();
            CanExecuteSettingsCommand = true;

        }
    }
}
