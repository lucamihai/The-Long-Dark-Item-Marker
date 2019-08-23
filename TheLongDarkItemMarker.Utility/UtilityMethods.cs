using System.Drawing;

namespace TheLongDarkItemMarker.Utility
{
    public static class UtilityMethods
    {
        public static Image GetZoomedImage(Image image, float zoomFactor)
        {
            var newSize = new Size((int)(image.Width * zoomFactor), (int)(image.Height * zoomFactor));
            var zoomedImage = new Bitmap(image, newSize);

            return zoomedImage;
        }
    }
}
