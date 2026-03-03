using App.DTOs.Countries;
using Domain.Entities;
using Infra.Repos.Interfaces;

namespace App.Services.Countries;

public class CountryService : ICountryService
{
    private readonly ICountryRepo _countryRepo;

    public CountryService(ICountryRepo countryRepo)
    {
        _countryRepo = countryRepo;
    }

    public void Add(CreateUpdateCountryDto input)
    {
        var country = new Country
        {
            Name = input.Name
        };
         _countryRepo.Add(country);
    }

    public void Delete(int id)
    {
        _countryRepo.Delete(id);
    }

    public List<ResponseCountryDto> GetAll()
    {
       return _countryRepo.GetAll().Select(c => new ResponseCountryDto { Id = c.Id, Name = c.Name}).ToList();
    }

    public ResponseCountryDto? GetById(int id)
    {
       var country = _countryRepo.GetById(id);

        if (country == null)
        {
            return null;
        }

        return new ResponseCountryDto
        {
            Id = country.Id,
            Name = country.Name
        };
    }

    public ResponseCountryDto? GetByName(string name)
    {
        var country = _countryRepo.GetByName(name);

        if (country == null)
        {
            return null;
        }

        return new ResponseCountryDto
        {
            Id = country.Id,
            Name = country.Name
        };
    }

    public void Update(int id, CreateUpdateCountryDto input)
    {
        var country = _countryRepo.GetById(id);

        if (country == null)
        {
            return;
        }

        country.Name = input.Name;
        _countryRepo.Update(country);
    }
}
