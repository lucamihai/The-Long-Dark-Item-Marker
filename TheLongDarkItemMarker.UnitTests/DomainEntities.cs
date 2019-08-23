using TheLongDarkItemMarker.Domain.Entities;

namespace TheLongDarkItemMarker.UnitTests
{
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
    }
}
