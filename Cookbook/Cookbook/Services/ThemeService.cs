using Cookbook.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Cookbook.Services
{
    internal class ThemeService : IThemeService
    {
        private readonly string MyThemeKey = "current_theme";
        public string GetCurrentTheme()
        {
            return Preferences.Get(MyThemeKey, "light");
        } 
        public void SwitchTheme(string theme)
        {
            var dictionaries = Application.Current.Resources.MergedDictionaries;
            dictionaries.Clear();

            if (theme == "dark")
            {
                dictionaries.Add(new Dark());
                Preferences.Set(MyThemeKey, theme);
            }
            else if (theme == "light")
            {
                dictionaries.Add(new Light());
                Preferences.Set(MyThemeKey, theme);
            }
            

           
            
        }
    }
}
