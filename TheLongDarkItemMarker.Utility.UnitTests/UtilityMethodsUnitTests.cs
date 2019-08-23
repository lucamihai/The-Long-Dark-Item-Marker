using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheLongDarkItemMarker.Utility.UnitTests
{
    [TestClass]
    public class UtilityMethodsUnitTests
    {
        private Image image;

        [TestInitialize]
        public void Setup()
        {
            image = Constants.Image;
        }

        [TestMethod]
        public void GetZoomedImageReturnsImageWithExpectedSize1()
        {
            var zoomedImage = UtilityMethods.GetZoomedImage(image, Constants.ZoomFactor1);

            Assert.AreEqual(Constants.ImageSizeAfterZoomFactor1, zoomedImage.Size);
        }

        [TestMethod]
        public void GetZoomedImageReturnsImageWithExpectedSize2()
        {
            var zoomedImage = UtilityMethods.GetZoomedImage(image, Constants.ZoomFactor2);

            Assert.AreEqual(Constants.ImageSizeAfterZoomFactor2, zoomedImage.Size);
        }
    }
}
