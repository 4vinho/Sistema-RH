using System.ComponentModel.DataAnnotations;

namespace EmployeeServiceAPI;

public class EmployeeDTO
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Phone]
    public string Phone { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime HiringDate { get; set; }

    [Required]
    public StatusEnum Status { get; set; } = StatusEnum.Active;

    [Required]
    [StringLength(11, MinimumLength = 11)]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve conter exatamente 11 dígitos numéricos.")]
    public string Cpf { get; set; } = string.Empty;

    [Required]
    public int DepartmentId { get; set; }

    [Required]
    [StringLength(100)]
    public string Position { get; set; } = string.Empty;

    [Required]
    [StringLength(200)]
    public string Roles { get; set; } = string.Empty;

    [Required]
    public int PayrollId { get; set; }
}
