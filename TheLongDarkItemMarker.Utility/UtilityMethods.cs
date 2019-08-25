using System.Drawing;
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
                    QuantityMaxValue = itemWithQuantity.QuantityMaxValue,
                    QuantityName = itemWithQuantity.QuantityName
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
                    QuantityMaxValue = itemWithConditionAndQuantity.QuantityMaxValue,
                    QuantityName = itemWithConditionAndQuantity.QuantityName
                };
            }

            return new Item
            {
                ItemCategory = item.ItemCategory,
                Name = item.Name,
                HowMany = item.HowMany,
            };
        }
    }
}
