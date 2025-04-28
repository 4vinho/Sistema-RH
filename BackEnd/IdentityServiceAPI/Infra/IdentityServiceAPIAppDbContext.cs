namespace IdentityServiceAPI;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class IdentityServiceAPIAppDbContext(DbContextOptions options) : IdentityDbContext<IdentityUser>(options)
{

}