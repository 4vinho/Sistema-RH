namespace EmployeeServiceAPI;

public class EmployeeDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public DateTime HiringDate { get; set; }
    public StatusEnum Status { get; set; } = StatusEnum.Active;
    public string Cpf { get; set; } = string.Empty;

    public int DepartmentId { get; set; }

    public string Position { get; set; } = string.Empty;
    public string Roles { get; set; } = string.Empty;

    public int PayrollId { get; set; }
}
