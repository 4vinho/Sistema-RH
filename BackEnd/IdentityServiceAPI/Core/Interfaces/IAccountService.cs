namespace IdentityServiceAPI;

public interface IAccountService
{
    public Task<Response<bool?>> Register(RegisterModel model);
    public Task<Response<string?>> Login(LoginModel model);
    public Task<Response<bool?>> Logout();
}
