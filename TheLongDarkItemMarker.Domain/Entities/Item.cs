namespace TheLongDarkItemMarker.Domain.Entities;

public class Item
{
    public ItemCategory ItemCategory { get; set; }
    public string Name { get; set; }
    public int HowMany { get; set; }
}