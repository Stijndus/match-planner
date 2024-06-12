using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Extensions.DependencyInjection;
using Matchplanner.Pages;

namespace Matchplanner
{
    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            var loginPage = serviceProvider.GetRequiredService<LoginPage>();
            MainPage = new NavigationPage(loginPage);
        }
    }
}
