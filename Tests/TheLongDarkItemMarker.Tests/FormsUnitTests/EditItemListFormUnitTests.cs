using System.Diagnostics.CodeAnalysis;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheLongDarkItemMarker.Forms;

namespace TheLongDarkItemMarker.Tests.FormsUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class EditItemListFormUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsArgumentNullExceptionForNullItemList()
        {
            var editItemListForm = new EditItemListForm(null);
        }

        [TestMethod]
        public void ConstructorSetsItemsPropertyForValidItemList()
        {
            var itemList = DomainEntities.ItemList;
            var editItemListForm = new EditItemListForm(itemList);

            var compareLogic = new CompareLogic();
            Assert.AreNotEqual(itemList, editItemListForm.Items);
            Assert.IsTrue(compareLogic.Compare(itemList, editItemListForm.Items).AreEqual);
        }
    }
}
