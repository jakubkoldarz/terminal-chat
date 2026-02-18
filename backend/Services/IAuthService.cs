namespace backend.services
{
    public interface IAuthService
    {
        Task LoginAsync();
        Task RegisterAsync();
    }
}
