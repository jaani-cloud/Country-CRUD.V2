using App.DTOs.Countries;

namespace App.DTOs.States;

public class StateResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int CountryId { get; set; }
    public ResponseCountryDto Country { get; set; } = new ResponseCountryDto(); 
}
