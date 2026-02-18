using backend.services;

namespace backend.Services
{
    public class AuthService : IAuthService
    {
        public Task LoginAsync()
        {
            return Task.CompletedTask;
        }

        public Task RegisterAsync()
        {
            return Task.CompletedTask;
        }
    }
}
