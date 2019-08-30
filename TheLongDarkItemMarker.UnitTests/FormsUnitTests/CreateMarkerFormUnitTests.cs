using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheLongDarkItemMarker.Forms;

namespace TheLongDarkItemMarker.UnitTests.FormsUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class CreateMarkerFormUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorThrowsArgumentExceptionForXPercentageSmallerThan0()
        {
            var createMarkerForm = new CreateMarkerForm(-1, Constants.MarkerYPercentage1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorThrowsArgumentExceptionForXPercentageBiggerThan100()
        {
            var createMarkerForm = new CreateMarkerForm(101, Constants.MarkerYPercentage1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorThrowsArgumentExceptionForYPercentageSmallerThan0()
        {
            var createMarkerForm = new CreateMarkerForm(Constants.MarkerXPercentage1, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorThrowsArgumentExceptionForYPercentageBiggerThan100()
        {
            var createMarkerForm = new CreateMarkerForm(Constants.MarkerXPercentage1, 101);
        }

        [TestMethod]
        public void ConstructorSetsXPercentageAndYPercentageForValidValues()
        {
            var xPercentage = Constants.MarkerXPercentage1;
            var yPercentage = Constants.MarkerYPercentage1;
            var createMarkerForm = new CreateMarkerForm(xPercentage, yPercentage);

            Assert.AreEqual(xPercentage, createMarkerForm.XPercentage);
            Assert.AreEqual(yPercentage, createMarkerForm.YPercentage);
        }
    }
}
