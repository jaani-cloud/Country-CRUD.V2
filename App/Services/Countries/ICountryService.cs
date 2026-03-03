using App.DTOs.Countries;

namespace App.Services.Countries;

public interface ICountryService
{
    public void Add(CreateUpdateCountryDto input);

    public List<ResponseCountryDto> GetAll();

    public ResponseCountryDto? GetById(int id);

    public void Update(int id, CreateUpdateCountryDto input);

    public void Delete(int id);

    public ResponseCountryDto? GetByName(string name);
}
