using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook.Services
{
    internal interface INavigationService
    {
        void NavigateToRecipeListViewModel();
        void NavigateToSettingsViewModel();
        void GoBack();
    }
}
