using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TheLongDarkItemMarker.Domain.Entities;
using TheLongDarkItemMarker.UnitTests.Common;

namespace TheLongDarkItemMarker.Utility.UnitTests
{
    [ExcludeFromCodeCoverage]
    public static class DomainEntities
    {
        public static Marker Marker1 => new Marker
        {
            Name = Constants.MarkerName1,
            XPositionPercentage = Constants.MarkerXPositionPercentage1,
            YPositionPercentage = Constants.MarkerYPositionPercentage1
        };

        public static Marker Marker2 => new Marker
        {
            Name = Constants.MarkerName2,
            XPositionPercentage = Constants.MarkerXPositionPercentage2,
            YPositionPercentage = Constants.MarkerYPositionPercentage2
        };

        public static List<Marker> Markers => new List<Marker>
        {
            Marker1,
            Marker2
        };
    }
}
