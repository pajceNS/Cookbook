using Cookbook.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Cookbook.Services
{
    internal class ThemeService : IThemeService
    {
        public void SwitchTheme(string theme)
        {
            var dictionaries = Application.Current.Resources.MergedDictionaries;
            dictionaries.Clear();

            if (theme == "dark")
            {
                dictionaries.Add(new Dark());
            }
            else if (theme == "light")
            {
                dictionaries.Add(new Light());
            }

           
            
        }
    }
}
