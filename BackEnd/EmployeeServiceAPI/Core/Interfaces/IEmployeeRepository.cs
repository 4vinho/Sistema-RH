namespace EmployeeServiceAPI;

public interface IEmployeeRepository
{
    Task<IEnumerable<EmployeeDTO>?> GetAllByStatusAsync(StatusEnum statusEnum);
    Task<EmployeeDTO?> GetByIdAsync(int id);
    Task<EmployeeDTO?> GetByCPFAsync(string CPF);
    Task<bool?> PostAsync(EmployeeDTO employeeDTO);
    Task<bool?> PutAsync(EmployeeDTO employeeDTO);
    Task<bool?> DeleteAsync(int id);
}
