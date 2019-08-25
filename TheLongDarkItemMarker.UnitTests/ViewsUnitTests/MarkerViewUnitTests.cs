using System;
using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheLongDarkItemMarker.Views;

namespace TheLongDarkItemMarker.UnitTests.ViewsUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class MarkerViewUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsArgumentNullExceptionForNullMarker()
        {
            var markerView = new MarkerView(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void ConstructorThrowsValidationExceptionForInvalidMarker()
        {
            var markerView = new MarkerView(DomainEntities.InvalidMarker);
        }

        [TestMethod]
        public void ConstructorSetsMarkerPropertyForValidMarker()
        {
            var marker = DomainEntities.Marker1;
            var markerView = new MarkerView(marker);

            Assert.AreEqual(marker, markerView.Marker);
        }
    }
}
