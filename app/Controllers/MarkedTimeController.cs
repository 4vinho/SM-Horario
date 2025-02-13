using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace SM_Horarios;

[ApiController]
[Route("api/[controller]")]
public class MarkedTimeController(IMarkedTimeHandler _markedTimeHandler) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateMarkedTimeAsync(MarkedTimeDTO tData)
    {
        var response = await _markedTimeHandler.CreateTDataAsync(tData);

        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteMarkedTimeAsync(int id)
    {
        var response = await _markedTimeHandler.DeleteByIdAsync(id);

        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }

    [HttpGet("byClientId/{clientId}")]
    public async Task<IActionResult> GetByClientIdAsync(
        int clientId,
        [FromQuery] PagedRequest pagedRequest
    )
    {
        var response = await _markedTimeHandler.GetByClientIdAsync(clientId, pagedRequest);
        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }

    [HttpGet("byEmployeeId/{employeeId}")]
    public async Task<IActionResult> GetByEmployeeIdAsync(
        int employeeId,
        [FromQuery] PagedRequest pagedRequest
    )
    {
        var response = await _markedTimeHandler.GetByEmployeeIdAsync(employeeId, pagedRequest);
        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }

    [HttpGet("byFirmId/{employeeId}")]
    public async Task<IActionResult> GetByFirmIdAsync(
        int firmId,
        [FromQuery] PagedRequest pagedRequest
    )
    {
        var response = await _markedTimeHandler.GetByFirmIdAsync(firmId, pagedRequest);
        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var response = await _markedTimeHandler.GetByIdAsync(id);

        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateMarkedTimeAsync(int id, MarkedTimeDTO tData)
    {
        var response = await _markedTimeHandler.UpdateByIdAsync(id, tData);

        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }
}
