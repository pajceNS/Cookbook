using Cookbook.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Xaml;

namespace Cookbook.Services
{
    internal class ViewModelLocator
    {
        private readonly IServiceProvider _serviceProvider;

        public ViewModelLocator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public MainViewModel MainViewModel
            => _serviceProvider.GetService<MainViewModel>();
        public RecipeListViewModel RecipeListViewModel
            => _serviceProvider.GetService<RecipeListViewModel>();
        public RecipeItemViewModel RecipeItemViewModel
            => _serviceProvider.GetService<RecipeItemViewModel>();
        public RecipeDetailsViewModel RecipeDetailsViewModel
            => _serviceProvider.GetService<RecipeDetailsViewModel>();
        public SettingsViewModel SettingsViewModel
            => _serviceProvider.GetService<SettingsViewModel>();

    }
}
