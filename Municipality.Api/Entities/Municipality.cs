using System.Text.Json.Serialization;

namespace Municipality.Api.Entities;

public class Municipality
{
    public int Id { get; set; }
    public string Mayor { get; set; }
    public string Party { get; set; }
    public int Population { get; set; }
}