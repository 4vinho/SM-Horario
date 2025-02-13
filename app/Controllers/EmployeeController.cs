using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace SM_Horarios;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController(IEmployeeHandler _employeeHandler) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateEmployeeAsync(EmployeeDTO tData)
    {
        var response = await _employeeHandler.CreateTDataAsync(tData);

        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteEmployeeAsync(int id)
    {
        var response = await _employeeHandler.DeleteByIdAsync(id);

        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployeeByIdAsync(int id)
    {
        var response = await _employeeHandler.GetByIdAsync(id);

        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }

    [HttpGet("byFirmId/{firmId}")]
    public async Task<IActionResult> GetEmployeeByFirmIdAsync(
        int firmId,
        [FromQuery] PagedRequest pagedRequest
    )
    {
        var response = await _employeeHandler.GetEmployeesByFirmIdAsync(firmId, pagedRequest);

        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateEmployeeAsync(int id, EmployeeDTO tData)
    {
        var response = await _employeeHandler.UpdateByIdAsync(id, tData);

        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }
}
