using Cookbook.DataAccess;
using Cookbook.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly INavigationService _navigationService;
    }
}
