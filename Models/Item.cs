namespace DnD_Companion.Models;

public class Item
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public int? Price { get; set; }
    public double Weight { get; set; }
    public string Description { get; set; }
}