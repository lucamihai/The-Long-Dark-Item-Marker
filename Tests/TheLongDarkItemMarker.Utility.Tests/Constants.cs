using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace TheLongDarkItemMarker.Utility.Tests;

[ExcludeFromCodeCoverage]
internal static class Constants
{
    public static Size ImageOriginalSize => new Size(100, 100);
    public static Image Image => new Bitmap(ImageOriginalSize.Width, ImageOriginalSize.Height);

    public const float ZoomFactor1 = 0.5f;
    public static Size ImageSizeAfterZoomFactor1 => new Size(50, 50);

    public const float ZoomFactor2 = 2;
    public static Size ImageSizeAfterZoomFactor2 => new Size(200, 200);
}