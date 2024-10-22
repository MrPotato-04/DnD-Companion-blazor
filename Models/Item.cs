

public class Item
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }
    
    [JsonPropertyName("price")]
    public int? Price { get; set; } // Nullable integer for Price
    
    [JsonPropertyName("weight")]
    public double Weight { get; set; }
    
    [JsonPropertyName("description")]
    public string Description { get; set; }
}