using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook.Services
{
    internal interface INavigationService
    {
        void NavigateToRecipeListViewModel(string mealName);
        void NavigateToSettingsViewModel();
        void GoBack();
        void NavigateToRecipeDetailsViewModel(Guid id);
    }
}
