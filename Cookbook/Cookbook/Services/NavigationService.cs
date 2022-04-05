using Cookbook.ViewModels;
using Cookbook.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Cookbook.Services
{
    internal class NavigationService : INavigationService
    {
        public void GoBack()
        {
            Application.Current.MainPage.Navigation.PopModalAsync();
            //var lastView = Application.Current.MainPage.Navigation.NavigationStack.Last();
            //if (lastView is MainPage mainPage
            //    && mainPage.BindingContext is MainViewModel mainViewModel)
            //{
            //    mainViewModel.LoadNotes();
            //}
        }

        public void NavigateToRecipeDetailsViewModel(Guid id)
        {
            Preferences.Set("stepCounter", 0
                );
            var vm = App.Locator.RecipeDetailsViewModel;
            vm.LoadRecipeWithId(id);
            Application.
                Current.
                MainPage.
                Navigation.
                PushModalAsync(new RecipeDetails { BindingContext = vm });
        }

        public void NavigateToRecipeListViewModel(string mealName)
        {
            var vm = App.Locator.RecipeListViewModel;
            vm.LoadRecipes(mealName);
            //vm.MealName = mealName;
            Application.
                Current.
                MainPage.
                Navigation.
                PushModalAsync(new RecipeList { BindingContext = vm});
        }
        public void NavigateToSettingsViewModel()
        {
            //var vm = App.Locator.RecipeListViewModel;
            var vm = App.Locator.SettingsViewModel;
            //vm.MealName = mealName;
            Application.
                Current.
                MainPage.
                Navigation.
                PushModalAsync(new Settings { BindingContext = vm});
            //throw new NotImplementedException();
        }
    }
}
