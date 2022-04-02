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
    internal class RecipeDetailsViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IRecipeRepository _recipeRepository;
        private ObservableCollection<RecipeStepItemViewModel> _stepSource;
        private ObservableCollection<RecipeStepItemViewModel> _ingredientsSource;
        private string _longDescription;
        //private string _name;
        //private string _backgroundImage;
        public RecipeDetailsViewModel(INavigationService navigationService, IRecipeRepository recipeRepository)
        {
            _navigationService = navigationService;
            _recipeRepository = recipeRepository;
            BackButtonClicked1 = new Command(OnBackButtonClicked);
        }
        public ObservableCollection<RecipeStepItemViewModel> IngredientsSource
        {
            get => _ingredientsSource;
            set
            {
                _ingredientsSource = value;
                OnPropertyChanged(nameof(IngredientsSource));
            }
        }

        public ICommand BackButtonClicked1 { get; }
        public ObservableCollection<RecipeStepItemViewModel> StepsSource
        {
            get => _stepSource;
            set
            {
                _stepSource= value;
                OnPropertyChanged(nameof(StepsSource));
            }
        }
        private void OnBackButtonClicked()
        {
            _navigationService.GoBack();
        }
        /*public string BackgroundImage
        {
            get => _backgroundImage; set
            {
                _backgroundImage = value;
                OnPropertyChanged(nameof(BackgroundImage));
            }
        }*/
        /*public string Name
        {
            get => _name;
            set
            {
                _name= value;
                OnPropertyChanged(nameof(Name));
            }
        }*/
        public string LongDescription
        {
            get => _longDescription;
            set
            {
                _longDescription = value;
                OnPropertyChanged(nameof(LongDescription));
            }
        }
        internal void LoadRecipeWithId(Guid id)
        {
            var recipe = _recipeRepository.GetRecipeForId(id);
            LongDescription = recipe[0].LongDescription;
            //Name = recipe[0].Name;
            //BackgroundImage = recipe[0].BackgroundImage;
            StepsSource = new ObservableCollection<RecipeStepItemViewModel>( recipe[0].Steps.Select(r => new RecipeStepItemViewModel(r)));
            IngredientsSource = new ObservableCollection<RecipeStepItemViewModel>(recipe[0].Ingredients.Select(r => new RecipeStepItemViewModel(r)));
        }

    }
}
