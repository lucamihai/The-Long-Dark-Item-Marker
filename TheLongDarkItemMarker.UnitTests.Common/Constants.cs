using System.Diagnostics.CodeAnalysis;

namespace TheLongDarkItemMarker.UnitTests.Common
{
    [ExcludeFromCodeCoverage]
    public static class Constants
    {
        public const string MarkerName1 = "MarkerName1";
        public const float MarkerXPositionPercentage1 = 10;
        public const float MarkerYPositionPercentage1 = 20;

        public const string MarkerName2 = "MarkerName2";
        public const float MarkerXPositionPercentage2 = 2.2f;
        public const float MarkerYPositionPercentage2 = 3.3f;

        public const string MarkersJsonString = "[{\"Name\":\"MarkerName1\",\"XPositionPercentage\":10.0,\"YPositionPercentage\":20.0},{\"Name\":\"MarkerName2\",\"XPositionPercentage\":2.2,\"YPositionPercentage\":3.3}]";
    }
}
