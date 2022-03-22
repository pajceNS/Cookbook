using Cookbook.DataAccess;
using Cookbook.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cookbook.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly INavigationService _navigationService;

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            ButtonSettings = new Command(OnButtonSettings);
            BrekfastButton = new Command(OnBrekfastButton);
            LunchButton = new Command(OnLunchButton);
            DinnerButton = new Command(OnDinnerButton);
        }

        

        public ICommand ButtonSettings { get; }
        public ICommand BrekfastButton { get; }
        public ICommand LunchButton { get; }
        public ICommand DinnerButton { get; }

        private void OnButtonSettings(object obj)
        {
            throw new NotImplementedException();   
        }
        private void OnBrekfastButton()
        {

            _navigationService.NavigateToRecipeListViewModel();
        }
        private void OnDinnerButton(object obj)
        {
            throw new NotImplementedException();
        }

        private void OnLunchButton(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
