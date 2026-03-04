using App.DTOs.Countries;
using App.DTOs.States;
using Domain.Entities;
using Infra.Repos.Interfaces;

namespace App.Services.States;

public class StateService : IStateService
{
    private readonly IStateRepo _stateRepo;
    private readonly ICountryRepo _countryRepo;

    public StateService(IStateRepo stateRepo, ICountryRepo countryRepo)
    {
        _stateRepo = stateRepo;
        _countryRepo = countryRepo;
    }

    public async Task Add(StateCreateUpdateDto input)
    {
        var country = _countryRepo.GetById(input.CountryId);

        if (country == null)
        {
            return;
        }

        State state = new State
        {
            Name = input.Name,
            CountryId = input.CountryId,
        };
        await _stateRepo.Add(state);
    }

    public async Task Delete(int id)
    {
        var state = await _stateRepo.GetById(id);

        if (state == null)
        {
            return;
        }
        await _stateRepo.Delete(state);
    }

    public async Task<List<StateResponseDto>> GetAll()
    {
        var states = await _stateRepo.GetAll();

        return states.Select(state => new StateResponseDto
        {
            Id = state.Id,
            Name = state.Name,
            CountryId = state.CountryId,
            Country = new ResponseCountryDto
            {
                Name = state.Country.Name,
                Id = state.Country.Id,
            }
        }).ToList();
    }

    public async Task<StateResponseDto?> GetById(int id)
    {
        var state = await _stateRepo.GetById(id);

        if (state == null)
        {
            return null;
        }

        return new StateResponseDto
        {
            Id = state.Id,
            Name = state.Name,
            CountryId = state.CountryId,
            Country = new ResponseCountryDto
            {
                Name = state.Country.Name,
                Id = state.Country.Id,
            }
        };
    }

    public async Task Update(StateCreateUpdateDto input, int id)
    {
        var state = await _stateRepo.GetById(id);

        if (state == null)
        {
            return;
        }

        var country = _countryRepo.GetById(input.CountryId);

        if (country == null)
        {
            return;
        }

        state.Name = input.Name;
        state.CountryId = input.CountryId;

        await _stateRepo.Update(state);

    }
}
