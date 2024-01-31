using System.Text.Json.Serialization;

namespace Tests.App.Cores;

public class Product
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("price")]
    public int Price { get; set; }

    [JsonPropertyName("category")]
    public string Category { get; set; }
}