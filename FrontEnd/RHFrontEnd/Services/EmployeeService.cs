using System.Net.Http.Json;
using System.Text.Json;

namespace RHFrontEnd;

public class EmployeeService(HttpClient _client) : IEmployeeService
{
    public const string BasePath = "api/Employee";

    public async Task<bool?> DeleteAsync(int id)
    {
        var response = await _client.DeleteAsync($"{BasePath}/{id}");

        if (!response.IsSuccessStatusCode)
            return null;

        var content = await response.Content.ReadAsStringAsync();
        var accountData = JsonSerializer.Deserialize<bool>(content);

        return accountData;
    }

    public async Task<IEnumerable<EmployeeModel>?> GetAllByStatusAsync(StatusEnum statusEnum)
    {
        //http://localhost:5263/api/Employee/status/statusEnum?statusEnum=0
        var response = await _client.GetAsync(
            $"{BasePath}/status/statusEnum?statusEnum={statusEnum}"
        );

        if (!response.IsSuccessStatusCode)
            return null;

        var content = await response.Content.ReadAsStringAsync();

        IEnumerable<EmployeeModel>? accountData =
            JsonSerializer.Deserialize<IEnumerable<EmployeeModel>?>(content);

        return accountData;
    }

    public async Task<EmployeeModel?> GetByCPFAsync(string CPF)
    {
        var response = await _client.GetAsync($"{BasePath}/cpf/{CPF}");

        if (!response.IsSuccessStatusCode)
            return null;

        var content = await response.Content.ReadAsStringAsync();
        var accountData = JsonSerializer.Deserialize<EmployeeModel>(content);

        return accountData;
    }

    public async Task<EmployeeModel?> GetByIdAsync(int id)
    {
        var response = await _client.GetAsync($"{BasePath}/{id}");

        if (!response.IsSuccessStatusCode)
            return null;

        var content = await response.Content.ReadAsStringAsync();
        var accountData = JsonSerializer.Deserialize<EmployeeModel>(content);

        return accountData;
    }

    public async Task<bool?> PostAsync(EmployeeModel employeeModel)
    {
        var response = await _client.PostAsJsonAsync($"{BasePath}", employeeModel);

        if (!response.IsSuccessStatusCode)
            return false;

        var content = await response.Content.ReadAsStringAsync();
        var accountData = JsonSerializer.Deserialize<bool>(content);

        return accountData;
    }

    public async Task<bool?> PutAsync(EmployeeModel employeeModel)
    {
        var response = await _client.PutAsJsonAsync($"{BasePath}", employeeModel);

        if (!response.IsSuccessStatusCode)
            return false;

        var content = await response.Content.ReadAsStringAsync();
        var accountData = JsonSerializer.Deserialize<bool>(content);

        return accountData;
    }
}
