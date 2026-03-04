using Domain.Entities;
using Infra.Data;
using Infra.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repos.Classes;

public class StateRepo : IStateRepo
{
    private readonly DataContext _context;

    public StateRepo(DataContext context)
    {
        _context = context;
    }
     
    public async Task Add(State state)
    {
        await _context.States.AddAsync(state);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(State state)
    {
        _context.States.Remove(state);
        await _context.SaveChangesAsync();
    }

    public async Task<List<State>> GetAll()
    {
        return await _context.States.Include(x => x.Country).ToListAsync();
    }

    public async Task<State?> GetById(int id)
    {
        return await _context.States.Include(x => x.Country).FirstOrDefaultAsync(i => id == i.Id); 
    }

    public async Task Update(State state)
    {
        _context.States.Update(state);
        await _context.SaveChangesAsync();
    }
}
