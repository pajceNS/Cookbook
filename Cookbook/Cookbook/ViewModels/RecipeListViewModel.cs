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

        public RecipeListViewModel()
        {
            MealName = "Dinner";
            BackButtonClicked = new Command(OnBackButtonClicked);
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
            throw new NotImplementedException();
        }
    }
}
