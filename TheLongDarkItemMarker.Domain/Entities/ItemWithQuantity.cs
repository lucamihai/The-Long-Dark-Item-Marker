﻿using TheLongDarkItemMarker.Domain.Interfaces;

namespace TheLongDarkItemMarker.Domain.Entities;

public class ItemWithQuantity : Item, IItemWithQuantity
{
    public string QuantityName { get; set; }
    public string QuantityPostfix { get; set; }
    public float Quantity { get; set; }
    public float QuantityMinValue { get; set; }
    public float QuantityMaxValue { get; set; }
}