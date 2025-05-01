namespace BusMessageServiceAPI;

public class MissonMessage : BaseMessage
{
    public List<int> EmployeeIds { get; set; } = new List<int>();
    public DateTime StartDate { get; set; }
    public DateTime? CompletionDate { get; set; }
    public string? Status { get; set; }
    public string? Priority { get; set; }
    public string? Description { get; set; }
}
