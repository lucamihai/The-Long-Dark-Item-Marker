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

        public static float GetZoomFactorForImageToFitInSpecifiedSize(Image image, Size size)
        {
            var maximumValueFromOriginalSize = image.Size.Width > image.Size.Height
                ? image.Size.Width
                : image.Size.Height;

            var minimumValueFromSpecifiedSize = size.Width < size.Height
                ? size.Width
                : size.Height;

            var zoomFactor = (float)minimumValueFromSpecifiedSize / maximumValueFromOriginalSize;

            return zoomFactor;
        }
    }
}
