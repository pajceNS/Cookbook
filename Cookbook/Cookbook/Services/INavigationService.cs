using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Services
{
    internal interface INavigationService
    {
        Task NavigateToRecipeListViewModel(string mealName);
        Task NavigateToSettingsViewModel();
        Task GoBack();
        Task NavigateToRecipeDetailsViewModel(Guid id);
    }
}
