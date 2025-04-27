using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MissionServiceAPI;

namespace MissionServiceAPI;

[Route("api/[controller]")]
[ApiController]
public class MissionController(IMissionRepository repository) : ControllerBase
{
    [HttpGet("status/{statusEnum}")]
    public async Task<IActionResult> GetByStatusAsync(StatusEnum statusEnum, [FromQuery] PagedRequest pagedRequest)
    {
        var response = await repository.GetByStatusAsync(statusEnum, pagedRequest);

        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var response = await repository.GetByIdAsync(id);

        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }

    [HttpGet("employeeId/{employeeId}")]
    public async Task<IActionResult> GetWorkItemsByEmployeeId(int employeeId, [FromQuery] PagedRequest pagedRequest)
    {
        var response = await repository.GetWorkItemsByEmployeeId(employeeId, pagedRequest);

        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] MissionDTO missionDTO)
    {
        var response = await repository.PostAsync(missionDTO);

        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync([FromBody] MissionDTO missionDTO)
    {
        var response = await repository.PutAsync(missionDTO);

        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var response = await repository.DeleteAsync(id);

        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }
}
