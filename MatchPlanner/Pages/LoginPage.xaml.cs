using Matchplanner.Services;
using Matchplanner.Shared.DTO;

namespace Matchplanner.Pages;
public partial class LoginPage : ContentPage
{
    private readonly IAuthService _authService;

    public LoginPage(IAuthService authService)
    {
        InitializeComponent();
        _authService = authService;
    }

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        // Validate the user credentials
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            MessageLabel.Text = "Please enter both username and password.";
            MessageLabel.IsVisible = true;
            return;
        }

        // Perform login (this is just a placeholder, implement your own authentication logic)
        bool isAuthenticated = await AuthenticateUser(username, password);

        if (isAuthenticated)
        {
            // Navigate to the next page or perform actions upon successful login
            await DisplayAlert("Success", "Login successful!", "OK");
            // For example, navigate to HomePage:
            await Navigation.PushAsync(new HomePage());
        }
        else
        {
            MessageLabel.Text = "Invalid username or password.";
            MessageLabel.IsVisible = true;
        }
    }

    private Task<bool> AuthenticateUser(string username, string password)
    {
        // Simulate a real authentication call
        var loginRequest = new LoginRequestDTO { Email = username, Password = password };
        return _authService.LoginAsync(loginRequest);
    }
}
