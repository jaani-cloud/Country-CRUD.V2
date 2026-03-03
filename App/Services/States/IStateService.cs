using App.DTOs.States;

namespace App.Services.States;

public interface IStateService
{
    public Task Add(StateCreateUpdateDto input);
    public Task Update(StateCreateUpdateDto input, int id);
    public Task Delete(int id);
    public Task<List<StateResponseDto>> GetAll();
    public Task<StateResponseDto> GetById(int id);
}
