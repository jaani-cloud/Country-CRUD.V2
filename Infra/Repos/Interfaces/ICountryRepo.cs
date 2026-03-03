using Domain.Entities;

namespace Infra.Repos.Interfaces;

public interface ICountryRepo
{
    public Country Add(Country country);
    public List<Country> GetAll();
    public Country? GetById(int id);
    public void Update(Country country);
    public void Delete(int id);
    public Country? GetByName(string name);
}
