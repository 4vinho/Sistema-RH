using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RHFrontEnd;

public class EmployeeModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("email")]
    [EmailAddress]
    public string? Email { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("dateOfBirth")]
    public DateTime DateOfBirth { get; set; }

    [JsonPropertyName("hiringDate")]
    public DateTime HiringDate { get; set; }

    [JsonPropertyName("status")]
    public StatusEnum? Status { get; set; }

    [JsonPropertyName("cpf")]
    public string? Cpf { get; set; }

    [JsonPropertyName("departmentId")]
    public int DepartmentId { get; set; }

    [JsonPropertyName("position")]
    public string? Position { get; set; }

    [JsonPropertyName("roles")]
    public string? Roles { get; set; }

    [JsonPropertyName("payrollId")]
    public int PayrollId { get; set; }
}
