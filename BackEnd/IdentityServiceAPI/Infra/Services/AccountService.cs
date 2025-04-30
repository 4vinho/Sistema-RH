using Microsoft.AspNetCore.Identity;

namespace IdentityServiceAPI;

public class AccountService(
    UserManager<IdentityUser> userManager,
    SignInManager<IdentityUser> signInManager,
    IJWTAuthService jWTAuthService)
    : IAccountService
{
    public async Task<Response<string?>> Login(LoginModel model)
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
                return new Response<string?>(200, "Logged successfully", jwtToken);
            }
            ;
            if (result.IsLockedOut)
                return new Response<string?>(400, "maximum login attempts reached", string.Empty);

            return new Response<string?>(404, "Incorrect Password or Email", string.Empty);
        }
        catch (Exception ex)
        {
            return new Response<string?>(500, "Internal Error", string.Empty);
        }
    }

    public async Task<Response<bool?>> Register(RegisterModel model)
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
            return new Response<bool?>(200, "Registered successfully", true);

            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            return new Response<bool?>(400, $"{errors}", false);
        }
        catch (Exception ex)
        {
            return new Response<bool?>(500, "Internal Error", false);
        }
    }

    public async Task<Response<bool?>> Logout()
    {
        try
        {
            await signInManager.SignOutAsync();

            return new Response<bool?>(200, "Logged out successfully", true);
        }
        catch (Exception ex)
        {
            return new Response<bool?>(500, "Internal Error", false);
        }
    }
}