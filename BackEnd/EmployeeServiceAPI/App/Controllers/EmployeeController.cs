using EmployeeServiceAPI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeServiceAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(IEmployeeRepository repository) : ControllerBase
    {
        [HttpGet("status/{statusEnum}/"), Authorize(Roles = "Admin, Owner")]
        public async Task<IActionResult> GetAllByStatusAsync(StatusEnum statusEnum, [FromQuery]PagedRequest pagedRequest)
        {
            var response = await repository.GetAllByStatusAsync(statusEnum, pagedRequest);

            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}"), Authorize(Roles = "Admin, Owner")]
        public async Task<IActionResult> GetAccountEmployeeAsync(int id)
        {
            var response = await repository.GetByIdAsync(id);

            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpGet("cpf/{CPF}"), Authorize(Roles = "Admin, Owner")]
        public async Task<IActionResult> GetAccountEmployeeAsync(string CPF)
        {
            var response = await repository.GetByCPFAsync(CPF);

            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpPost, Authorize(Roles = "Owner")]
        public async Task<IActionResult> PostAsync([FromBody] EmployeeDTO employeeDTO)
        {
            var response = await repository.PostAsync(employeeDTO);

            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpPut, Authorize(Roles = "Admin, Owner")]
        public async Task<IActionResult> PutAsync([FromBody] EmployeeDTO employeeDTO)
        {
            var response = await repository.PutAsync(employeeDTO);

            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Owner")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await repository.DeleteAsync(id);

            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
    }
}
