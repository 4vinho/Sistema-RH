
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IdentityServiceAPI;

public class LoginModel
{
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [PasswordPropertyText]
    public string Password { get; set; } = string.Empty;
    public bool RememberMe { get; set; }
}
