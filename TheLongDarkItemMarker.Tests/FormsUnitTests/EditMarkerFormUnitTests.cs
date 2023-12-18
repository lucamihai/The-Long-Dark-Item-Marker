using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheLongDarkItemMarker.Forms;

namespace TheLongDarkItemMarker.Tests.FormsUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class EditMarkerFormUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsArgumentNullExceptionForNullMarker()
        {
            var editMarkerForm = new EditMarkerForm(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void ConstructorThrowsValidationExceptionForInvalidMarker()
        {
            var editMarkerForm = new EditMarkerForm(DomainEntities.InvalidMarker);
        }

        [TestMethod]
        public void ConstructorDoesNotThrowAnyExceptionForValidMarker()
        {
            var editMarkerForm = new EditMarkerForm(DomainEntities.Marker1);
        }
    }
}
