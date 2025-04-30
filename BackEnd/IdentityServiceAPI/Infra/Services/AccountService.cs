using Microsoft.AspNetCore.Identity;

namespace IdentityServiceAPI;

public class AccountService(
    UserManager<IdentityUser> userManager,
    SignInManager<IdentityUser> signInManager,
    IJWTAuthService jWTAuthService)
    : IAccountService
{
    public async Task<(bool Success, string Error)> Login(LoginModel model)
    {
        try
        {
            var result = await signInManager.PasswordSignInAsync(
                model.Email,
                model.Password,
                model.RememberMe,
                lockoutOnFailure: true
            );

            if (result.Succeeded)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                var roles = await userManager.GetRolesAsync(user);
                var role = roles.FirstOrDefault() ?? "User";
                var jwtToken = jWTAuthService.GenerateTokenString(model, role);
                 return (true, jwtToken);
            }
            ;
            if (result.IsLockedOut)
                return (false, "Conta bloqueada devido a várias tentativas inválidas.");

            return (false, "Email ou senha inválidos.");
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }

    public async Task<(bool Success, string Error)> Register(RegisterModel model)
    {
        try
        {
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.Phone
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
                return (true, string.Empty);

            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            return (false, errors);
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }

    public async Task<(bool Success, string Error)> Logout()
    {
        try
        {
            await signInManager.SignOutAsync();

            return (true, string.Empty);
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }
}