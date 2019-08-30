using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TheLongDarkItemMarker.Domain.Entities;

namespace TheLongDarkItemMarker.UnitTests
{
    [ExcludeFromCodeCoverage]
    internal static class DomainEntities
    {
        public static Map Map1 => new Map
        {
            Name = Constants.MapName1,
            Image = Constants.MapImage1
        };

        public static Map InvalidMap => new Map
        {
            Name = null,
            Image = Constants.MapImage1
        };

        public static List<Item> ItemList => new List<Item>
        {
            Item1
        };

        public static Item Item1 => new Item
        {
            ItemCategory = Constants.ItemCategory1,
            Name = Constants.ItemName1,
            HowMany = Constants.ItemHowMany1
        };

        public static Marker Marker1 => new Marker
        {
            Name = Constants.MarkerName1,
            XPositionPercentage = Constants.MarkerXPercentage1,
            YPositionPercentage = Constants.MarkerYPercentage1
        };

        public static Marker InvalidMarker => new Marker
        {
            Name = Constants.MarkerName1,
            XPositionPercentage = -1,
            YPositionPercentage = Constants.MarkerYPercentage1
        };
    }
}
