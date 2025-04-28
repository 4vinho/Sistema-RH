namespace IdentityServiceAPI;

public interface ISeedUserRoleInitial
{
    Task SeedRolesAsync();
    Task SeedUsersAsync();
}
