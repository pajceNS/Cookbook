using Cookbook.ViewModels;
using Cookbook.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Cookbook.Services
{
    internal class NavigationService : INavigationService
    {
        public async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }

        public async Task NavigateToRecipeDetailsViewModel(Guid id)
        {
            Preferences.Set("stepCounter", 0);
            var vm = App.Locator.RecipeDetailsViewModel;
            vm.LoadRecipeWithId(id);
            await Application.
                Current.
                MainPage.
                Navigation.
                PushModalAsync(new RecipeDetails { BindingContext = vm });
        }

        public async Task NavigateToRecipeListViewModel(string mealName)
        {
            var vm = App.Locator.RecipeListViewModel;
            vm.LoadRecipes(mealName);
            await Application.
                Current.
                MainPage.
                Navigation.
                PushModalAsync(new RecipeList { BindingContext = vm });
        }
        public async Task NavigateToSettingsViewModel()
        {
            var vm = App.Locator.SettingsViewModel;
            await Application.
                Current.
                MainPage.
                Navigation.
                PushModalAsync(new Settings { BindingContext = vm });
        }
    }
}
