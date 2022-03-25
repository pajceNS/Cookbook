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

        private readonly string MyThemeKey = "currentTheme";
        public string GetCurrentTheme()
        {
            return Preferences.Get(MyThemeKey, "Light");
        } 
        public void SwitchTheme(string theme)
        {
            var dictionaries = Application.Current.Resources.MergedDictionaries;
            dictionaries.Clear();
            
            if (theme == "Dark")
            {
                dictionaries.Add(new Light());
                Preferences.Set(MyThemeKey, "Light");
            }
            else if (theme == "Light")
            {
                dictionaries.Add(new Dark());
                Preferences.Set(MyThemeKey, "Dark");
            }          
        }
    }
}
