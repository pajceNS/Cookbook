using Cookbook.DataAccess;
using Cookbook.Models;
using Cookbook.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
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

        public RecipeListViewModel(INavigationService navigationService, IRecipeRepository recipeRepository)
        {
            BackButtonClicked = new Command(OnBackButtonClicked);
            _recipeRepository = recipeRepository;
            _navigationService = navigationService;
            SelectedRecipeCommand = new Command(OnSelectedRecipeCommand);
            //var testList = new List<RecipeItemViewModel>()
            //{
            //    new RecipeItemViewModel(new Recipe(Guid.NewGuid(),"recept1","desc1","Slika.png","Sasd","Sasd","Sasd","Sasd","Sasd","Sasd","Sasd","Sasd")),
            //    //new RecipeItemViewModel(new Recipe(Guid.NewGuid(),"recept1","desc1","Slika.png"))
                
            //};
            //RecipeSource = new ObservableCollection<RecipeItemViewModel>(testList);
        }
        
        public ObservableCollection<RecipeItemViewModel> RecipeSource
            {
                get { return _recipeSource; }
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
        public ObservableCollection<RecipeItemViewModel> Items { get; set; }
        public ICommand BackButtonClicked { get; }
        public ICommand SelectedRecipeCommand { get; }
        public RecipeItemViewModel SelectedRecipe
        {
            get => _selectedRecipe;
            set
            {
                _selectedRecipe = value;
                OnPropertyChanged(nameof(SelectedRecipe));
            }
        }
        private void OnBackButtonClicked()
        {
            _navigationService.GoBack();
        }
        internal void LoadRecipes(string mealName)
        {
            var allRecipesForType = _recipeRepository.GetRecipesForType(mealName)
                .Select(r => new RecipeItemViewModel(r));
            RecipeSource = new ObservableCollection<RecipeItemViewModel>(allRecipesForType);
            MealName = mealName;
        }

        public void OnSelectedRecipeCommand()
        {
            var clickedRecipe = SelectedRecipe.GetRecipe();
            var s = clickedRecipe.Id;
            _navigationService.NavigateToRecipeDetailsViewModel(clickedRecipe.Id);
        }
    }
}
