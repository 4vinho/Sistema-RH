
using Microsoft.AspNetCore.Identity;

namespace IdentityServiceAPI;

public class SeedUserRoleInitial(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager) : ISeedUserRoleInitial
{
    public async Task SeedRolesAsync()
    {
        if (!await roleManager.RoleExistsAsync("User"))
        {
            var role = new IdentityRole();

            role.Name = "User";
            role.NormalizedName = "USER";
            role.ConcurrencyStamp = Guid.NewGuid().ToString();

            IdentityResult roleResult = await roleManager.CreateAsync(role);
        }

        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            var role = new IdentityRole();

            role.Name = "Admin";
            role.NormalizedName = "ADMIN";
            role.ConcurrencyStamp = Guid.NewGuid().ToString();

            IdentityResult roleResult = await roleManager.CreateAsync(role);
        }

        if (!await roleManager.RoleExistsAsync("Owner"))
        {
            var role = new IdentityRole();

            role.Name = "Owner";
            role.NormalizedName = "OWNER";
            role.ConcurrencyStamp = Guid.NewGuid().ToString();

            IdentityResult roleResult = await roleManager.CreateAsync(role);
        }
    }

    public async Task SeedUsersAsync()
    {
        if (await userManager.FindByEmailAsync("usuario@localhost") == null)
        {
            var user = new IdentityUser();
            user.UserName = "usuario@localhost";
            user.NormalizedUserName = "USUARIO@LOCALHOST";
            user.Email = "usuario@localhost";
            user.NormalizedEmail = "USUARIO@LOCALHOST";
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = await userManager.CreateAsync(user, "Numsey#2025");

            if (result.Succeeded)
                await userManager.AddToRoleAsync(user, "User");
        }

        if (await userManager.FindByEmailAsync("Admin@localhost") == null)
        {
            var user = new IdentityUser();
            user.UserName = "Admin@localhost";
            user.NormalizedUserName = "ADMIN@LOCALHOST";
            user.Email = "Admin@localhost";
            user.NormalizedEmail = "ADMIN@LOCALHOST";
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = await userManager.CreateAsync(user, "Numsey#2025");

            if (result.Succeeded)
                await userManager.AddToRoleAsync(user, "Admin");
        }

        if (await userManager.FindByEmailAsync("Owner@localhost") == null)
        {
            var user = new IdentityUser();
            user.UserName = "Owner@localhost";
            user.NormalizedUserName = "OWNER@LOCALHOST";
            user.Email = "Owner@localhost";
            user.NormalizedEmail = "OWNER@LOCALHOST";
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = await userManager.CreateAsync(user, "Numsey#2025");

            if (result.Succeeded)
                await userManager.AddToRoleAsync(user, "Owner");
        }
    }
}
