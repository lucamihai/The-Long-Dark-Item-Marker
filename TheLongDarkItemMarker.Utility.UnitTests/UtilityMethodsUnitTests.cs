using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheLongDarkItemMarker.Utility.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class UtilityMethodsUnitTests
    {
        [TestMethod]
        public void GetZoomedImageReturnsImageWithExpectedSize1()
        {
            var zoomedImage = UtilityMethods.GetZoomedImage(Constants.Image, Constants.ZoomFactor1);

            Assert.AreEqual(Constants.ImageSizeAfterZoomFactor1, zoomedImage.Size);
        }

        [TestMethod]
        public void GetZoomedImageReturnsImageWithExpectedSize2()
        {
            var zoomedImage = UtilityMethods.GetZoomedImage(Constants.Image, Constants.ZoomFactor2);

            Assert.AreEqual(Constants.ImageSizeAfterZoomFactor2, zoomedImage.Size);
        }

        [TestMethod]
        public void GetZoomFactorForImageToFitInSpecifiedSizeReturnsExpectedZoomFactor1()
        {
            var zoomFactor = UtilityMethods.GetZoomFactorForImageToFitInSpecifiedSize(Constants.Image, Constants.ImageSizeAfterZoomFactor1);

            Assert.AreEqual(Constants.ZoomFactor1, zoomFactor);
        }

        [TestMethod]
        public void GetZoomFactorForImageToFitInSpecifiedSizeReturnsExpectedZoomFactor2()
        {
            var zoomFactor = UtilityMethods.GetZoomFactorForImageToFitInSpecifiedSize(Constants.Image, Constants.ImageSizeAfterZoomFactor2);

            Assert.AreEqual(Constants.ZoomFactor2, zoomFactor);
        }
    }
}
