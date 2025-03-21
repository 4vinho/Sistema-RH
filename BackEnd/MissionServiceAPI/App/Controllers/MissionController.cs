using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MissionServiceAPI;

namespace MissionServiceAPI;

[Route("api/[controller]")]
[ApiController]
public class MissionController(IMissionRepository repository) : ControllerBase
{
    [HttpGet("status/{statusEnum}")]
    public async Task<IActionResult> GetByStatusAsync(StatusEnum statusEnum)
    {
        var response = await repository.GetByStatusAsync(statusEnum);

        if (response == null)
            return NotFound();

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var response = await repository.GetByIdAsync(id);

        if (response == null)
            return NotFound();

        return Ok(response);
    }

    [HttpGet("employeeId/{employeeId}")]
    public async Task<IActionResult> GetWorkItemsByEmployeeId(int employeeId)
    {
        var response = await repository.GetWorkItemsByEmployeeId(employeeId);

        if (response == null)
            return NotFound();

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] MissionDTO missionDTO)
    {
        var response = await repository.PostAsync(missionDTO);

        if (response == null)
            return BadRequest();

        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync([FromBody] MissionDTO missionDTO)
    {
        var response = await repository.PutAsync(missionDTO);

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
