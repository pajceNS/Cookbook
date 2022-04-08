using Cookbook.DataAccess;
using Cookbook.Resources;
using Cookbook.Services;
using Cookbook.ViewModels;
using Cookbook.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cookbook
{
    public partial class App : Application
    {
        private static ViewModelLocator _viewLocator;
        private static IServiceProvider _serviceProvider;
        public App()
        {
            InitializeComponent();
            SetupServices();
            MainPage = new NavigationPage(new MainPage { BindingContext = Locator.MainViewModel });

        }
        internal static ViewModelLocator Locator
        {
            get
            {
                if(_viewLocator is null)
                {
                    _viewLocator = new ViewModelLocator(_serviceProvider);
                }
                return _viewLocator;
            }
        }
        protected override void OnStart()
        {
        }
        protected override void OnSleep()
        {
        }
        protected override void OnResume()
        {
        }
        private void SetupServices()
        {
            var themeService = new ThemeService();
            if (themeService.GetCurrentTheme() == "Light")
            {
                Current.Resources.MergedDictionaries.Add(new Light());
            }
            else
            {
                Current.Resources.MergedDictionaries.Add(new Dark());
            }

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<MainViewModel>();
            serviceCollection.AddTransient<RecipeListViewModel>();
            serviceCollection.AddTransient<RecipeDetailsViewModel>();
            serviceCollection.AddTransient<RecipeItemViewModel>();
            serviceCollection.AddTransient<SettingsViewModel>();
            serviceCollection.AddSingleton<IThemeService>(themeService);
            serviceCollection.AddSingleton<IRecipeRepository, RecipeRepository>();
            serviceCollection.AddSingleton<INavigationService, NavigationService>();
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
