using Cookbook.Resources;
using Cookbook.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cookbook.ViewModels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    internal partial class SettingsViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;

        public SettingsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SwitchTheme = new Command(() => Update());
        }

        public void Update()
        {
            var mergedDictionaries = Xamarin.Forms.Application.Current.Resources.
                MergedDictionaries;

            mergedDictionaries.Clear();
            mergedDictionaries.Add(new Dark());

        }

        public void Toggled_handler(object sender, ToggledEventArgs e)
        {
            Update();
        }

        public ICommand SwitchTheme { get; }

        //private void OnSwitchTheme(object sender, ToggledEventArgs e)
        //{
        //    var mergedDictionaries = Xamarin.Forms.Application.Current.Resources.
        //        MergedDictionaries;

        //    mergedDictionaries.Clear();
        //    mergedDictionaries.Add(new Dark());
        //}
    }
}
