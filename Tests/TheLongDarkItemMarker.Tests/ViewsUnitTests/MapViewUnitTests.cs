using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheLongDarkItemMarker.Views;

namespace TheLongDarkItemMarker.Tests.ViewsUnitTests;

[TestClass]
[ExcludeFromCodeCoverage]
public class MapViewUnitTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ConstructorThrowsArgumentNullExceptionForNullMap()
    {
        var mapView = new MapView(null);
    }

    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void ConstructorThrowsValidationExceptionExceptionForInvalidMap()
    {
        var mapView = new MapView(DomainEntities.InvalidMap);
    }

    [TestMethod]
    public void ConstructorSetsMapPropertyIfMapIsValid()
    {
        var map = DomainEntities.Map1;
        var mapView = new MapView(map);

        Assert.AreEqual(map, mapView.Map);
    }
}