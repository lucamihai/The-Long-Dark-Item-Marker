namespace TheLongDarkItemMarker.Domain.Interfaces
{
    public interface IItemWithQuantity
    {
        string QuantityName { get; set; }
        string QuantityPostfix { get; set; }
        float Quantity { get; set; }
        float QuantityMinValue { get; set; }
        float QuantityMaxValue { get; set; }
    }
}
