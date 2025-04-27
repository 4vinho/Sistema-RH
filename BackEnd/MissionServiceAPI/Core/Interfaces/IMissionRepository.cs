namespace MissionServiceAPI;

public interface IMissionRepository
{
    Task<Response<MissionDTO?>> GetByIdAsync(int Id);
    Task<PagedResponse<IEnumerable<MissionDTO>?>> GetWorkItemsByEmployeeId(int employeeId, PagedRequest pagedRequest);
    Task<PagedResponse<IEnumerable<MissionDTO>?>> GetByStatusAsync(StatusEnum statusEnum, PagedRequest pagedRequest);
    Task<Response<MissionDTO?>> PostAsync(MissionDTO missionDTO);
    Task<Response<MissionDTO?>> PutAsync(MissionDTO missionDTO);
    Task<Response<bool?>> DeleteAsync(int id);
}
