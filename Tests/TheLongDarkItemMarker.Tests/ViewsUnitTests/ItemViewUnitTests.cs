using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheLongDarkItemMarker.Views;

namespace TheLongDarkItemMarker.Tests.ViewsUnitTests;

[TestClass]
[ExcludeFromCodeCoverage]
public class ItemViewUnitTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ConstructorThrowsArgumentNullExceptionForNullItem()
    {
        var itemView = new ItemView(null);
    }

    [TestMethod]
    public void ConstructorSetsItemPropertyForValidItem()
    {
        var item = DomainEntities.Item1;
        var itemView = new ItemView(item);

        Assert.AreEqual(item, itemView.Item);
    }
}