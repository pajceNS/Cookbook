using Cookbook.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cookbook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        private int _counter = 0;
        public Settings()
        {
            InitializeComponent();
        }

        private void SwitchButton_Toggled(object sender, ToggledEventArgs e)
        {
            var mergedDictionaries = Xamarin.Forms.Application.Current.Resources.
                MergedDictionaries;

            mergedDictionaries.Clear();
            if (_counter % 2 == 0)
            {
                mergedDictionaries.Add(new Dark());
                _counter++;
            }
            else
            {
                mergedDictionaries.Add(new Light());
                _counter++;
            }
        }
    }
}