namespace MissionServiceAPI;

public interface IMissionRepository
{
    Task<MissionDTO?> GetByIdAsync(int Id);
    Task<IEnumerable<MissionDTO>?> GetWorkItemsByEmployeeId(int employeeId);
    Task<IEnumerable<MissionDTO>?> GetByStatusAsync(StatusEnum statusEnum);
    Task<bool?> PostAsync(MissionDTO missionDTO);
    Task<bool?> PutAsync(MissionDTO missionDTO);
    Task<bool?> DeleteAsync(int id);
}
