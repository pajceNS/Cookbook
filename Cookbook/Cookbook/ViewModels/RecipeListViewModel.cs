using Cookbook.DataAccess;
using Cookbook.Models;
using Cookbook.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace Cookbook.ViewModels
{
    internal class RecipeListViewModel : BaseViewModel 
    {
        private string _mealName;
        private readonly INavigationService _navigationService;
        private readonly IRecipeRepository _recipeRepository;
        private ObservableCollection<RecipeItemViewModel> _recipeSource;
        private RecipeItemViewModel _selectedRecipe;
        private bool _canExecuteSettingsCommand = true;

        public RecipeListViewModel(INavigationService navigationService, IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
            _navigationService = navigationService;
            BackButtonClicked = new AsyncCommand(OnBackButtonClicked, () => CanExecuteSettingsCommand);
            SelectedRecipeCommand = new AsyncCommand(OnSelectedRecipeCommand, () => CanExecuteSettingsCommand);
        }
        public ICommand BackButtonClicked { get; }
        public ICommand SelectedRecipeCommand { get; }

        private bool CanExecuteSettingsCommand
        {
            get => _canExecuteSettingsCommand;
            set
            {
                _canExecuteSettingsCommand = value;
                ((AsyncCommand)BackButtonClicked).ChangeCanExecute();
                ((AsyncCommand)SelectedRecipeCommand).ChangeCanExecute();
            }
        }

        public ObservableCollection<RecipeItemViewModel> Items { get; set; }

        public ObservableCollection<RecipeItemViewModel> RecipeSource
        {
            get => _recipeSource;
            set
            {
            _recipeSource = value;
            OnPropertyChanged(nameof(RecipeSource));
            }
        }     
        public string MealName
        {
            get => _mealName;
            set
            {
                _mealName = value;
                OnPropertyChanged(nameof(MealName));
            }
        }

        public RecipeItemViewModel SelectedRecipe
        {
            get => _selectedRecipe;
            set
            {
                _selectedRecipe = value;
                OnPropertyChanged(nameof(SelectedRecipe));
            }
        }

        private async Task OnSelectedRecipeCommand()
        {
            if (SelectedRecipe != null)
            {
                var clickedRecipe = SelectedRecipe.GetRecipe();
                CanExecuteSettingsCommand = false;
                await _navigationService.NavigateToRecipeDetailsViewModel(clickedRecipe.Id);
                CanExecuteSettingsCommand = true;
            }
            SelectedRecipe = null;
        }

        internal void LoadRecipes(string mealName)
        {
            var allRecipesForType = _recipeRepository.GetRecipesForType(mealName)
                .Select(r => new RecipeItemViewModel(r));
            RecipeSource = new ObservableCollection<RecipeItemViewModel>(allRecipesForType);
            MealName = mealName;
        }

        private async Task OnBackButtonClicked()
        {
            CanExecuteSettingsCommand = false;
            await _navigationService.GoBack();
            CanExecuteSettingsCommand = true;
        }
    }
}
