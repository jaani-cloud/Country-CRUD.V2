using Domain.Entities;
using Infra.Data;
using Infra.Repos.Interfaces;

namespace Infra.Repos.Classes;

public class CountryRepo : ICountryRepo
{
    private readonly DataContext _context;

    public CountryRepo(DataContext context)
    {
        _context = context;
    }

    public Country Add(Country country)
    {
        _context.Countries.Add(country);
        _context.SaveChanges();

        return country;
    }

    public void Delete(int id)
    {
        var country = _context.Countries.Find(id);

        if (country == null)
        {
            return;
        }
        _context.Countries.Remove(country);
        _context.SaveChanges();
    }

    public List<Country> GetAll()
    {
        return _context.Countries.ToList();
    }

    public Country? GetById(int id)
    {
        var country = _context.Countries.Find(id);

        return country;
    }

    public Country? GetByName(string name)
    {
        var country = _context.Countries.FirstOrDefault(country => name.ToLower() == country.Name.ToLower());

        return country;
    }

    public void Update(Country country)
    {
        var countryToUpdate = _context.Countries.Find(country.Id);

        if (countryToUpdate == null)
        {
            return;
        }
        countryToUpdate.Name = country.Name;
        _context.SaveChanges();
    }
}
