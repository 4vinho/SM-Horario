using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace SM_Horarios;

[ApiController]
[Route("api/[controller]")]
public class FirmController(IFirmHandler _firmHandler) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateFirmAsync(FirmDTO tData)
    {
        var response = await _firmHandler.CreateTDataAsync(tData);

        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteFirmAsync(int id)
    {
        var response = await _firmHandler.DeleteByIdAsync(id);

        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFirmByIdAsync(int id)
    {
        var response = await _firmHandler.GetByIdAsync(id);

        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }

    [HttpGet("byName/{name}")]
    public async Task<IActionResult> GetFirmByNameAsync(
        string name,
        [FromQuery] PagedRequest pagedRequest
    )
    {
        var response = await _firmHandler.GetFirmByNameAsync(name, pagedRequest);

        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateByIdAsync(int id, FirmDTO tData)
    {
        var response = await _firmHandler.UpdateByIdAsync(id, tData);

        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }
}
