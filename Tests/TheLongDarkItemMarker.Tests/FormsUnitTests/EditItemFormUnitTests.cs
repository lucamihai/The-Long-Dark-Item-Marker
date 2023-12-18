using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheLongDarkItemMarker.Forms;

namespace TheLongDarkItemMarker.Tests.FormsUnitTests;

[TestClass]
[ExcludeFromCodeCoverage]
public class EditItemFormUnitTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ConstructorThrowsArgumentNullExceptionForNullItem()
    {
        var editItemForm = new EditItemForm(null);
    }

    [TestMethod]
    public void ConstructorDoesNotThrowAnyExceptionForValidItem()
    {
        var editItemForm = new EditItemForm(DomainEntities.Item1);
    }
}