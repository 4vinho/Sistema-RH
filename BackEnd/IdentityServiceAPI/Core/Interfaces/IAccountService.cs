namespace IdentityServiceAPI;

public interface IAccountService
{
    public Task<(bool Success, string Error)> Register(RegisterModel model);
    public Task<(bool Success, string Error)> Login(LoginModel model);
    public Task<(bool Success, string Error)> Logout();
}
