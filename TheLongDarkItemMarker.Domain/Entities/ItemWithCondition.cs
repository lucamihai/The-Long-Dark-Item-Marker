using TheLongDarkItemMarker.Domain.Interfaces;

namespace TheLongDarkItemMarker.Domain.Entities;

public class ItemWithCondition : Item, IItemWithCondition
{
    public byte Condition { get; set; }
}