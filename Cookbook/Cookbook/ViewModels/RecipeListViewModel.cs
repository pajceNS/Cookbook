using Cookbook.DataAccess;
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

        public RecipeListViewModel(INavigationService navigationService,IRecipeRepository recipeRepository)

        {
            //TO BE CONTINUED
            // 
            /* 
             * napraviti konstruktor za type, ubaciti ga u kontejner, ovde ga uvezati
             */

            BackButtonClicked = new Command(OnBackButtonClicked);
            _recipeRepository = recipeRepository;
            _navigationService = navigationService;
            var allRecipesForType = _recipeRepository.GetRecipesForType("lunch")
                .Select(r => new RecipeItemViewModel(r));

            //Items = new ObservableCollection<RecipeItemViewModel>(allRecipesForType)
            //{
            //    new RecipeItemViewModel(),
            //    new RecipeItemViewModel()

            //};

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
        //public void OnRecipeClickedCommand()
        //{
        //    //var clickedRecipe = selectedItem.GetRecipe();
        //    _navigationService.navigateToRecipeDetailsModel();

        //}
    }
}
