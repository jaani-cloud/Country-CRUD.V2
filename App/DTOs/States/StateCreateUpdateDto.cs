using System.Security.Cryptography.X509Certificates;

namespace App.DTOs.States;

public class StateCreateUpdateDto
{
    public string Name { get; set; } = string.Empty;
    public int CountryId { get; set; }

}
