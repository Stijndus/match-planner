using Matchplanner.Shared.Models;
using Matchplanner.Shared.DTO;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;

namespace Matchplanner.Services
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(LoginRequestDTO dto);
        Task<bool> isUserAuthenticated(string username, string password);
    }

    public class AuthService : IAuthService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> LoginAsync(LoginRequestDTO dto)
        {
            var httpClient = _httpClientFactory.CreateClient(AppConstants.HttpClientName);
            httpClient.BaseAddress = new Uri("http://localhost:5141/");

            var response = await httpClient.PostAsJsonAsync<LoginRequestDTO>("api/auth/login", dto);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                UserModel authResponse =
                    JsonSerializer.Deserialize<UserModel>(content, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                if (authResponse.Id != null)
                {
                    var serializedData = JsonSerializer.Serialize(authResponse);
                    await SecureStorage.Default.SetAsync("email", JsonSerializer.Serialize(authResponse.Email));
                    await SecureStorage.Default.SetAsync("password", JsonSerializer.Serialize(authResponse.Password));
                    await SecureStorage.Default.SetAsync("user_id", JsonSerializer.Serialize(authResponse.Id));
                    await SecureStorage.Default.SetAsync("team_id", JsonSerializer.Serialize(authResponse.TeamID));
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        public async Task<bool> isUserAuthenticated(string username, string password)
        {
            if (username != null && password != null)
            {
                return true;

            } else
            {
                return false;
            }
        }
    }
}
