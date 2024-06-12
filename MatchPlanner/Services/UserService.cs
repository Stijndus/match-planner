using System.Net.Http.Headers;
using System.Text.Json;

namespace Matchplanner.Services
{
    public class UserService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IAuthService _authService;

        public UserService(IHttpClientFactory httpClientFactory, IAuthService authService)
        {
            _httpClientFactory = httpClientFactory;
            _authService = authService;
        }
    }
}
