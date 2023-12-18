using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using TheLongDarkItemMarker.Domain.Entities;

namespace TheLongDarkItemMarker.Tests;

[ExcludeFromCodeCoverage]
internal static class Constants
{
    public static string MapName1 => "MapName1";
    public static Image MapImage1 => new Bitmap(100, 100);

    public static ItemCategory ItemCategory1 => ItemCategory.Tool;
    public static string ItemName1 => "ItemName1";
    public static int ItemHowMany1 => 2;

    public static string MarkerName1 => "MarkerName1";
    public static float MarkerXPercentage1 => 10f;
    public static float MarkerYPercentage1 => 2.1f;
}