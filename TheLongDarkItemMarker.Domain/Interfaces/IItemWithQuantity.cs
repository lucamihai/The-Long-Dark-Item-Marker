namespace TheLongDarkItemMarker.Domain.Interfaces
{
    public interface IItemWithQuantity
    {
        string QuantityName { get; set; }
        float Quantity { get; set; }
        float QuantityMaxValue { get; set; }
    }
}
