using App.DTOs.Countries;
using App.Services.Countries;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/country")]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly ICountryService _countryService;
    public CountryController(ICountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpPost("add")]
    public void Add(CreateUpdateCountryDto input)
    {
        _countryService.Add(input);
    }

    [HttpGet("get-all")]
    public List<ResponseCountryDto> GetAll()
    {
        return _countryService.GetAll();
    }

    [HttpGet("get-by-id/{id}")]
    public ResponseCountryDto? Get(int id)
    {
        var country = _countryService.GetById(id);

        return country;
    }

    [HttpPut("update/{id}")]
    public void Update(int id, CreateUpdateCountryDto input)
    {
        _countryService.Update(id, input);
    }

    [HttpDelete("delete/{id}")]
    public void Delete(int id)
    {
        _countryService.Delete(id);
    }

    [HttpGet("get-by-name/{name}")]
    public ResponseCountryDto? GetByName(string name)
    {
        var country = _countryService.GetByName(name);
        return country;
    }


}
