using Cookbook.DataAccess;
using Cookbook.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Cookbook.ViewModels
{
    internal class RecipeDetailsViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IRecipeRepository _recipeRepository;
        private ObservableCollection<RecipeStepItemViewModel> _stepSoruce;
        private string _longDescription;
        public RecipeDetailsViewModel(INavigationService navigationService, IRecipeRepository recipeRepository)
        {
            _navigationService = navigationService;
            _recipeRepository = recipeRepository;

        }


        public ObservableCollection<RecipeStepItemViewModel> StepsSource
        {
            get => _stepSoruce;
            set
            {
                _stepSoruce= value;
                OnPropertyChanged(nameof(StepsSource));
            }
        }
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
        }

    }
}
