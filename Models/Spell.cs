public class Spell
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("level")]
    public int Level { get; set; }
    
    [JsonPropertyName("school")]
    public string School { get; set; }
    
    [JsonPropertyName("casting_time")]
    public string CastingTime { get; set; }
    
    [JsonPropertyName("range")]
    public string Range { get; set; }
    
    [JsonPropertyName("duration")]
    public string Duration { get; set; }
    
    [JsonPropertyName("description")]
    public string Description { get; set; }
}