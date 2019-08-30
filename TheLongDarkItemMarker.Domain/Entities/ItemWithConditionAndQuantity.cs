using TheLongDarkItemMarker.Domain.Interfaces;

namespace TheLongDarkItemMarker.Domain.Entities
{
    public class ItemWithConditionAndQuantity : Item, IItemWithCondition, IItemWithQuantity
    {
        public byte Condition { get; set; }
        public string QuantityName { get; set; }
        public string QuantityPostfix { get; set; }
        public float Quantity { get; set; }
        public float QuantityMaxValue { get; set; }
    }
}
