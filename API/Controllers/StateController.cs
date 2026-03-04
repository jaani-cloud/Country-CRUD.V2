using App.DTOs.States;
using App.Services.States;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/state")]
[ApiController]
public class StateController : ControllerBase
{
    private readonly IStateService _stateService;

    public StateController(IStateService stateService)
    {
        _stateService = stateService;
    }

    [HttpPost("add")]
    public async Task Add(StateCreateUpdateDto input)
    {
        await _stateService.Add(input);
    }

    [HttpPut("upate/{id}")]
    public async Task Update(StateCreateUpdateDto input, int id)
    {
        await _stateService.Update(input, id);
    }

    [HttpDelete("delete/{id}")]
    public async Task Delete(int id)
    {
        await _stateService.Delete(id);
    }

    [HttpGet("get-by-id/{id}")]
    public async Task<StateResponseDto> GetById(int id)
    {
        return await _stateService.GetById(id);
    }

    [HttpGet("get-all")]
    public async Task<List<StateResponseDto>> GetAll()
    {
        return await _stateService.GetAll();
    }
}
