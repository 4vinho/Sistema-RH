using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IdentityServiceAPI;

public class RegisterModel
{
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [PasswordPropertyText]
    public string Password { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public DateTime HiringDate { get; set; }
    public string Cpf { get; set; } = string.Empty;

    public int DepartmentId { get; set; }

    public string Position { get; set; } = string.Empty;
    public string Roles { get; set; } = string.Empty;

    public int PayrollId { get; set; }
}
