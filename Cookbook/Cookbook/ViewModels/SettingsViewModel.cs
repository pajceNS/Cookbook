using Cookbook.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cookbook.ViewModels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    internal partial class SettingsViewModel : BaseViewModel
    {
        public SettingsViewModel()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void SwitchButton_Toggled(object sender, ToggledEventArgs e)
        {
            var mergedDictionaries = Xamarin.Forms.Application.Current.Resources.MergedDictionaries;
            mergedDictionaries.Clear();
            mergedDictionaries.Add(new Dark());
        }
    }
}
