namespace Cookbook.Services
{
    internal interface IThemeService
    {
        string GetCurrentTheme();
        void SwitchTheme(string theme);
    }
}