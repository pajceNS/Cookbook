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
            _themeService = themeService;
            _navigationService = navigationService;
            SwitchThemeCommand = new Command(OnSwitchThemeCommand);
            SwitchTheme = _themeService.GetCurrentTheme() == "Light";
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
            var currentTheme = Preferences.Get("currentTheme", "Light");
            _themeService.SwitchTheme(currentTheme);          
        }
    }
}
