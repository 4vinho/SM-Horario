using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace SM_Horarios;

[ApiController]
[Route("api/[controller]")]
public class ClientController(IClientHandler _clientHandler) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateClientAsync(ClientDTO client)
    {
        var response = await _clientHandler.CreateTDataAsync(client);

        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteClientAsync(int id)
    {
        var response = await _clientHandler.DeleteByIdAsync(id);

        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetClientByIdAsync(int id)
    {
        var response = await _clientHandler.GetByIdAsync(id);

        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }

    [HttpGet("byName/{clientName}")]
    public async Task<IActionResult> GetClientByNameAsync(
        string clientName,
        [FromQuery] PagedRequest pagedRequest
    )
    {
        var response = await _clientHandler.GetClientByNameAsync(clientName, pagedRequest);

        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateClientAsync(int id, ClientDTO tData)
    {
        var response = await _clientHandler.UpdateByIdAsync(id, tData);

        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }
}
