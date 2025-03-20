namespace RHFrontEnd;

using System.Net;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeModel>?> GetAllByStatusAsync(StatusEnum statusEnum);
    Task<EmployeeModel?> GetByIdAsync(int id);
    Task<EmployeeModel?> GetByCPFAsync(string CPF);
    Task<bool?> PostAsync(EmployeeModel employeeModel);
    Task<bool?> PutAsync(EmployeeModel employeeModel);
    Task<bool?> DeleteAsync(int id);
}
