using System.Text.Json.Serialization;

namespace Municipality.Api.Dtos;

public class MunicipalityDto
{
    [JsonPropertyName("municipioid")] public int Id { get; set; }
    [JsonPropertyName("alcalde")]  public string Mayor { get; set; }
    [JsonPropertyName("partidopolitico")]  public string Party { get; set; }
    [JsonPropertyName("numhabitantes")] public int Population { get; set; }
}