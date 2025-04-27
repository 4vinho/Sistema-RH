namespace EmployeeServiceAPI;

public interface IEmployeeRepository
{
    Task<PagedResponse<IEnumerable<EmployeeDTO>?>> GetAllByStatusAsync(StatusEnum statusEnum, PagedRequest pagedRequest);
    Task<Response<EmployeeDTO?>> GetByIdAsync(int id);
    Task<Response<EmployeeDTO?>> GetByCPFAsync(string CPF);
    Task<Response<EmployeeDTO?>> PostAsync(EmployeeDTO employeeDTO);
    Task<Response<EmployeeDTO?>> PutAsync(EmployeeDTO employeeDTO);
    Task<Response<bool?>> DeleteAsync(int id);
}
