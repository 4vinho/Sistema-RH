namespace MissionServiceAPI;

public class MissionDTO
{
    public int Id { get; set; }
    public List<int> EmployeeIds { get; set; } = new List<int>();
    public DateTime? StartDate { get; set; }
    public DateTime? CompletionDate { get; set; }
    public StatusEnum? Status { get; set; }
    public PriorityEnum? Priority { get; set; }
    public string? Description { get; set; }
}
