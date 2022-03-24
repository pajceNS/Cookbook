using Cookbook.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            Items = new ObservableCollection<RecipeItemViewModel>()
            {
                new RecipeItemViewModel(),
                new RecipeItemViewModel()

            };

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
    }
}
