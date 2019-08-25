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

        public const string MarkersJsonString =
@"{
  ""$type"": ""System.Collections.Generic.List`1[[TheLongDarkItemMarker.Domain.Entities.Marker, TheLongDarkItemMarker.Domain]], mscorlib"",
  ""$values"": [
    {
      ""$type"": ""TheLongDarkItemMarker.Domain.Entities.Marker, TheLongDarkItemMarker.Domain"",
      ""Name"": ""MarkerName1"",
      ""XPositionPercentage"": 10.0,
      ""YPositionPercentage"": 20.0,
      ""Items"": {
        ""$type"": ""System.Collections.Generic.List`1[[TheLongDarkItemMarker.Domain.Entities.Item, TheLongDarkItemMarker.Domain]], mscorlib"",
        ""$values"": []
      }
    },
    {
      ""$type"": ""TheLongDarkItemMarker.Domain.Entities.Marker, TheLongDarkItemMarker.Domain"",
      ""Name"": ""MarkerName2"",
      ""XPositionPercentage"": 2.2,
      ""YPositionPercentage"": 3.3,
      ""Items"": {
        ""$type"": ""System.Collections.Generic.List`1[[TheLongDarkItemMarker.Domain.Entities.Item, TheLongDarkItemMarker.Domain]], mscorlib"",
        ""$values"": []
      }
    }
  ]
}";

        public const string ItemsJsonString =
@"{
        ""$type"": ""System.Collections.Generic.List`1[[TheLongDarkItemMarker.Domain.Entities.Item, TheLongDarkItemMarker.Domain]], mscorlib"",
        ""$values"": [
          {
            ""$type"": ""TheLongDarkItemMarker.Domain.Entities.Item, TheLongDarkItemMarker.Domain"",
            ""ItemCategory"": 0,
            ""Name"": ""Stick"",
            ""HowMany"": 1
          },
          {
            ""$type"": ""TheLongDarkItemMarker.Domain.Entities.ItemWithCondition, TheLongDarkItemMarker.Domain"",
            ""Condition"": 100,
            ""ItemCategory"": 4,
            ""Name"": ""Sewing Kit"",
            ""HowMany"": 1
          },
          {
            ""$type"": ""TheLongDarkItemMarker.Domain.Entities.ItemWithQuantity, TheLongDarkItemMarker.Domain"",
            ""QuantityName"": ""Liter"",
            ""Quantity"": 1.0,
            ""QuantityMaxValue"": 1.0,
            ""ItemCategory"": 3,
            ""Name"": ""Water Potable"",
            ""HowMany"": 1
          },
          {
            ""$type"": ""TheLongDarkItemMarker.Domain.Entities.ItemWithConditionAndQuantity, TheLongDarkItemMarker.Domain"",
            ""Condition"": 100,
            ""QuantityName"": ""Rifle Cartridge"",
            ""Quantity"": 0.0,
            ""QuantityMaxValue"": 10.0,
            ""ItemCategory"": 4,
            ""Name"": ""Hunting Rifle"",
            ""HowMany"": 1
          }
        ]
      }";
    }
}
