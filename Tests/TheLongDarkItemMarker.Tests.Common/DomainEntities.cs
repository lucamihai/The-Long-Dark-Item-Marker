using System.Diagnostics.CodeAnalysis;
using TheLongDarkItemMarker.Domain.Entities;

namespace TheLongDarkItemMarker.Tests.Common;

[ExcludeFromCodeCoverage]
public static class DomainEntities
{
    public static List<Marker> Markers => new List<Marker>
    {
        Marker1,
        Marker2
    };

    public static Marker Marker1 => new Marker
    {
        Name = Constants.MarkerName1,
        XPositionPercentage = Constants.MarkerXPositionPercentage1,
        YPositionPercentage = Constants.MarkerYPositionPercentage1
    };

    public static Marker Marker2 => new Marker
    {
        Name = Constants.MarkerName2,
        XPositionPercentage = Constants.MarkerXPositionPercentage2,
        YPositionPercentage = Constants.MarkerYPositionPercentage2
    };

    public static List<Item> Items => new List<Item>
    {
        Item1,
        Item2,
        Item3,
        Item4
    };

    public static Item Item1 => new Item
    {
        ItemCategory = ItemCategory.FireStarting,
        HowMany = 1,
        Name = "Stick"
    };

    public static Item Item2 => new ItemWithCondition
    {
        ItemCategory = ItemCategory.Tool,
        HowMany = 1,
        Name = "Sewing Kit",
        Condition = 100
    };

    public static Item Item3 => new ItemWithQuantity
    {
        ItemCategory = ItemCategory.FoodAndDrink,
        HowMany = 1,
        Name = "Water Potable",
        Quantity = 1,
        QuantityMaxValue = 1,
        QuantityName = "Liter",
        QuantityPostfix = "s"
    };

    public static Item Item4 => new ItemWithConditionAndQuantity
    {
        ItemCategory = ItemCategory.Tool,
        HowMany = 1,
        Name = "Hunting Rifle",
        Condition = 100,
        Quantity = 0,
        QuantityMaxValue = 10,
        QuantityName = "Rifle Cartridge",
        QuantityPostfix = "s"
    };

}