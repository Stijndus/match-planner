using Matchplanner.Services;
using Matchplanner.Pages;

namespace Matchplanner;
public partial class MainPage : ContentPage
{
    private readonly IAuthService _authService;
    public MainPage(IAuthService authService)
    {
        InitializeComponent();
        _authService = authService;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {

        string email = await SecureStorage.GetAsync("email");
        string password = await SecureStorage.GetAsync("password");

        base.OnNavigatedTo(args);
        if (await _authService.isUserAuthenticated(email, password))
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
        else
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
