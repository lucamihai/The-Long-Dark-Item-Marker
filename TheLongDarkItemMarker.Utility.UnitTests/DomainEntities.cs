using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TheLongDarkItemMarker.Domain.Entities;

namespace TheLongDarkItemMarker.Utility.UnitTests
{
    [ExcludeFromCodeCoverage]
    internal static class DomainEntities
    {
        public static List<Item> ItemList => new List<Item>
        {
            ItemSimple,
            ItemWithCondition,
            ItemWithQuantity,
            ItemWithConditionAndQuantity
        };

        public static Item ItemSimple => new Item
        {
            ItemCategory = ItemCategory.FirstAid,
            Name = "Name1",
            HowMany = 2
        };

        public static Item ItemWithCondition => new ItemWithCondition
        {
            ItemCategory = ItemCategory.Clothing,
            Name = "Name2",
            HowMany = 1,
            Condition = 81
        };

        public static Item ItemWithQuantity => new ItemWithQuantity
        {
            ItemCategory = ItemCategory.FoodAndDrink,
            Name = "Name3",
            HowMany = 4,
            Quantity = 0.4f,
            QuantityMaxValue = 1,
            QuantityName = "Liter"
        };

        public static Item ItemWithConditionAndQuantity => new ItemWithConditionAndQuantity
        {
            ItemCategory = ItemCategory.Tool,
            Name = "Name4",
            HowMany = 1,
            Quantity = 3,
            QuantityMaxValue = 10,
            QuantityName = "Rifle cartridge"
        };
    }
}
