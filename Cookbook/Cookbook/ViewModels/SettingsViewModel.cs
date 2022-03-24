using Cookbook.Resources;
using Cookbook.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cookbook.ViewModels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    internal partial class SettingsViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IThemeService _themeService;
        
        private bool _switchTheme;

        public SettingsViewModel(INavigationService navigationService,IThemeService themeService)
        {
            SwitchThemeCommand = new Command(OnSwitchThemeCommand);
            var currentTheme = Preferences.Get("current_theme", "light");

            if(currentTheme == "dark")
            {
                SwitchTheme = true;
            }
            else
            {
                SwitchTheme = false;
            }
            _navigationService = navigationService;
            _themeService = themeService;
        }

        public ICommand SwitchThemeCommand { get; }
        public bool SwitchTheme 
        {
            get => _switchTheme;
            set
            {
                _switchTheme = value;
                OnPropertyChanged(nameof(SwitchTheme));
            }
        }

        private void OnSwitchThemeCommand(object obj)
        {
            _themeService.SwitchTheme("light");
            
            var currentTheme = Preferences.Get("current_theme", "light");
        }
    }
}
