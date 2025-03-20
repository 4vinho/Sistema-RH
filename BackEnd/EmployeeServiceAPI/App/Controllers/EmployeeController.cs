using EmployeeServiceAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeServiceAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(IEmployeeRepository repository) : ControllerBase
    {
        [HttpGet("status/statusEnum")]
        public async Task<IActionResult> GetAllByStatusAsync(StatusEnum statusEnum)
        {
            var response = await repository.GetAllByStatusAsync(statusEnum);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountEmployeeAsync(int id)
        {
            var response = await repository.GetByIdAsync(id);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpGet("cpf/{CPF}")]
        public async Task<IActionResult> GetAccountEmployeeAsync(string CPF)
        {
            var response = await repository.GetByCPFAsync(CPF);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] EmployeeDTO employeeDTO)
        {
            var response = await repository.PostAsync(employeeDTO);

            if (response == null)
                return BadRequest();

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] EmployeeDTO employeeDTO)
        {
            var response = await repository.PutAsync(employeeDTO);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await repository.DeleteAsync(id);

            if (response == null)
                return NotFound();

            return Ok(response);
        }
    }
}
