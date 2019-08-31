using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TheLongDarkItemMarker.Domain.Entities;

namespace TheLongDarkItemMarker.Utility
{
    public static class UtilityMethods
    {
        public static Image GetZoomedImage(Image image, float zoomFactor)
        {
            var newSize = new Size((int)(image.Width * zoomFactor), (int)(image.Height * zoomFactor));
            var zoomedImage = new Bitmap(image, newSize);

            return zoomedImage;
        }

        public static float GetZoomFactorForImageToFitInSpecifiedSize(Image image, Size size)
        {
            var maximumValueFromOriginalSize = image.Size.Width > image.Size.Height
                ? image.Size.Width
                : image.Size.Height;

            var minimumValueFromSpecifiedSize = size.Width < size.Height
                ? size.Width
                : size.Height;

            var zoomFactor = (float)minimumValueFromSpecifiedSize / maximumValueFromOriginalSize;

            return zoomFactor;
        }

        public static Item GetItemClone(Item item)
        {
            var type = item.GetType();

            if (type == typeof(ItemWithCondition))
            {
                var itemWithCondition = (ItemWithCondition)item;

                return new ItemWithCondition
                {
                    ItemCategory = itemWithCondition.ItemCategory,
                    Name = itemWithCondition.Name,
                    HowMany = itemWithCondition.HowMany,
                    Condition = itemWithCondition.Condition
                };
            }

            if (type == typeof(ItemWithQuantity))
            {
                var itemWithQuantity = (ItemWithQuantity)item;

                return new ItemWithQuantity
                {
                    ItemCategory = itemWithQuantity.ItemCategory,
                    Name = itemWithQuantity.Name,
                    HowMany = itemWithQuantity.HowMany,
                    Quantity = itemWithQuantity.Quantity,
                    QuantityMinValue = itemWithQuantity.QuantityMinValue,
                    QuantityMaxValue = itemWithQuantity.QuantityMaxValue,
                    QuantityName = itemWithQuantity.QuantityName,
                    QuantityPostfix = itemWithQuantity.QuantityPostfix
                };
            }

            if (type == typeof(ItemWithConditionAndQuantity))
            {
                var itemWithConditionAndQuantity = (ItemWithConditionAndQuantity)item;

                return new ItemWithConditionAndQuantity
                {
                    ItemCategory = itemWithConditionAndQuantity.ItemCategory,
                    Name = itemWithConditionAndQuantity.Name,
                    HowMany = itemWithConditionAndQuantity.HowMany,
                    Condition = itemWithConditionAndQuantity.Condition,
                    Quantity = itemWithConditionAndQuantity.Quantity,
                    QuantityMinValue = itemWithConditionAndQuantity.QuantityMinValue,
                    QuantityMaxValue = itemWithConditionAndQuantity.QuantityMaxValue,
                    QuantityName = itemWithConditionAndQuantity.QuantityName,
                    QuantityPostfix = itemWithConditionAndQuantity.QuantityPostfix
                };
            }

            return new Item
            {
                ItemCategory = item.ItemCategory,
                Name = item.Name,
                HowMany = item.HowMany,
            };
        }

        public static Item GetItemFromListSimilarToProvidedItem(List<Item> items, Item itemToSearch)
        {
            if (itemToSearch is ItemWithCondition itemWithCondition)
            {
                return items.OfType<ItemWithCondition>().FirstOrDefault(item =>
                    item.ItemCategory == itemWithCondition.ItemCategory
                    && item.Name == itemWithCondition.Name
                    && item.Condition == itemWithCondition.Condition);
            }

            if (itemToSearch is ItemWithQuantity itemWithQuantity)
            {
                return items.OfType<ItemWithQuantity>().FirstOrDefault(item =>
                    item.ItemCategory == itemWithQuantity.ItemCategory
                    && item.Name == itemWithQuantity.Name
                    && item.Quantity == itemWithQuantity.Quantity
                    && item.QuantityMinValue == itemWithQuantity.QuantityMinValue
                    && item.QuantityMaxValue == itemWithQuantity.QuantityMaxValue
                    && item.QuantityName == itemWithQuantity.QuantityName);
            }

            if (itemToSearch is ItemWithConditionAndQuantity itemWithConditionAndQuantity)
            {
                return items.OfType<ItemWithConditionAndQuantity>().FirstOrDefault(item =>
                    item.ItemCategory == itemWithConditionAndQuantity.ItemCategory
                    && item.Name == itemWithConditionAndQuantity.Name
                    && item.Condition == itemWithConditionAndQuantity.Condition
                    && item.Quantity == itemWithConditionAndQuantity.Quantity
                    && item.QuantityMinValue == itemWithConditionAndQuantity.QuantityMinValue
                    && item.QuantityMaxValue == itemWithConditionAndQuantity.QuantityMaxValue
                    && item.QuantityName == itemWithConditionAndQuantity.QuantityName);
            }

            var simpleItems = items.Where(x => !(x is ItemWithCondition)
                                               && !(x is ItemWithQuantity)
                                               && !(x is ItemWithConditionAndQuantity));

            return simpleItems.FirstOrDefault(x => x.ItemCategory == itemToSearch.ItemCategory
                                                   && x.Name == itemToSearch.Name);
        }
    }
}
