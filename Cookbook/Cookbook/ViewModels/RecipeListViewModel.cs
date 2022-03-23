using Cookbook.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cookbook.ViewModels
{
    internal class RecipeListViewModel : BaseViewModel 
    {
        private string _mealName;
        private readonly INavigationService _navigationService;

        public RecipeListViewModel(INavigationService navigationService)
        {
            BackButtonClicked = new Command(OnBackButtonClicked);

            _navigationService = navigationService;
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

        public ICommand BackButtonClicked { get; }

        private void OnBackButtonClicked()
        {
            _navigationService.GoBack();
        }
    }
}
