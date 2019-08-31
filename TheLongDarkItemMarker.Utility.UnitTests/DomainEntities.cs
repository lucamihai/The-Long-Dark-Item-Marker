using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TheLongDarkItemMarker.Domain.Entities;

namespace TheLongDarkItemMarker.Utility.UnitTests
{
    [ExcludeFromCodeCoverage]
    internal static class DomainEntities
    {
        public static List<Item> ItemList1 => new List<Item>
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
            QuantityMinValue = 0.1f,
            QuantityMaxValue = 1,
            QuantityName = "Liter"
        };

        public static Item ItemWithConditionAndQuantity => new ItemWithConditionAndQuantity
        {
            ItemCategory = ItemCategory.Tool,
            Name = "Name4",
            HowMany = 1,
            Quantity = 3,
            QuantityMinValue = 0,
            QuantityMaxValue = 10,
            QuantityName = "Rifle cartridge"
        };

        public static List<Item> ItemList2 => new List<Item>
        {
            ItemFireStarting,
            ItemFirstAid,
            ItemClothing,
            ItemFoodAndDrink,
            ItemTool,
            ItemMaterial
        };

        public static Item ItemFireStarting => new Item
        {
            ItemCategory = ItemCategory.FireStarting,
            Name = "Fire starting item",
            HowMany = 1
        };

        public static Item ItemFirstAid => new Item
        {
            ItemCategory = ItemCategory.FirstAid,
            Name = "First aid item",
            HowMany = 1
        };

        public static Item ItemClothing => new Item
        {
            ItemCategory = ItemCategory.Clothing,
            Name = "Clothing item",
            HowMany = 1
        };

        public static Item ItemFoodAndDrink => new Item
        {
            ItemCategory = ItemCategory.FoodAndDrink,
            Name = "Food and drink item",
            HowMany = 1
        };

        public static Item ItemTool => new Item
        {
            ItemCategory = ItemCategory.Tool,
            Name = "Tool item",
            HowMany = 1
        };

        public static Item ItemMaterial => new Item
        {
            ItemCategory = ItemCategory.Material,
            Name = "Material item",
            HowMany = 1
        };

    }
}
