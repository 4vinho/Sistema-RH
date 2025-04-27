using System.ComponentModel.DataAnnotations;

namespace MissionServiceAPI;

public class MissionDTO
{
    public int Id { get; set; }

    [MinLength(1, ErrorMessage = "At least one employee ID must be provided.")]
    public List<int> EmployeeIds { get; set; } = new List<int>();

    [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
    public DateTime? StartDate { get; set; }

    [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
    public DateTime? CompletionDate { get; set; }

    [EnumDataType(typeof(StatusEnum), ErrorMessage = "Invalid status.")]
    public StatusEnum? Status { get; set; }

    [EnumDataType(typeof(PriorityEnum), ErrorMessage = "Invalid priority.")]
    public PriorityEnum? Priority { get; set; }

    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string? Description { get; set; }
}
