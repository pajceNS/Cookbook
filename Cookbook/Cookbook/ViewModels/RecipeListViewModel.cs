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
        public RecipeListViewModel(INavigationService navigationService, IRecipeRepository recipeRepository)
        {
            BackButtonClicked = new Command(OnBackButtonClicked);
            _recipeRepository = recipeRepository;
            _navigationService = navigationService;
            //var testList = new List<RecipeItemViewModel>()
            //{
            //    new RecipeItemViewModel(new Recipe(Guid.NewGuid(),"recept1","desc1","Slika.png")),
            //    new RecipeItemViewModel(new Recipe(Guid.NewGuid(),"recept1","desc1","Slika.png"))
            //};          
        }
        //Items = new ObservableCollection<RecipeItemViewModel>(allRecipesForType)
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
        //public void OnRecipeClickedCommand()
        //{
        //    //var clickedRecipe = selectedItem.GetRecipe();
        //    _navigationService.navigateToRecipeDetailsModel();
        //}
    }
}
