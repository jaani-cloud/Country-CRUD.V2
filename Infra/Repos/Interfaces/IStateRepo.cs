using Domain.Entities;

namespace Infra.Repos.Interfaces;

public interface IStateRepo
{
    public Task Add(State state);
    public Task<List<State>> GetAll();
    public Task Upate(State state);
    public Task<State?> GetById(int id); 
    public Task Delete(State state); 
}
