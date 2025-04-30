namespace IdentityServiceAPI;

public interface IJWTAuthService
{
    public string GenerateTokenString(LoginModel loginModel, string role);
}
