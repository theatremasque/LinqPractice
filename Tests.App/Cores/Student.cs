using System.Text.Json.Serialization;

namespace Tests.App.Cores;

public class Student
{
    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    [JsonPropertyName("average_score")]
    public int AverageScore { get; set; }
}