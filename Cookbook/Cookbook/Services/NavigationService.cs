using Cookbook.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Cookbook.Services
{
    internal class NavigationService : INavigationService
    {
        public void GoBack()
        {
            throw new NotImplementedException();
        }

        public void NavigateToRecipeListViewModel()
        {
            var vm = App.Locator.RecipeListViewModel;
            Application.
                Current.
                MainPage.
                Navigation.
                PushModalAsync(new RecipeList { BindingContext = vm});
        }

        public void NavigateToSettingsViewModel()
        {
            throw new NotImplementedException();
        }
    }
}
