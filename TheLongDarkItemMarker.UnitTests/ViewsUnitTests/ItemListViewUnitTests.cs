using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheLongDarkItemMarker.Domain.Entities;
using TheLongDarkItemMarker.Enums;
using TheLongDarkItemMarker.Views;

namespace TheLongDarkItemMarker.UnitTests.ViewsUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ItemListViewUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsArgumentNullExceptionForNullItemList()
        {
            var itemListView = new ItemListView(null, ItemListViewSelection.None);
        }

        [TestMethod]
        public void ConstructorSetsItemsPropertyForValidItemList()
        {
            var itemList = DomainEntities.ItemList;
            var itemListView = new ItemListView(itemList, ItemListViewSelection.None);

            Assert.AreEqual(itemList, itemListView.Items);
        }

        [TestMethod]
        public void ConstructorSetsItemListViewSelectionProperty()
        {
            var itemListViewSelection = ItemListViewSelection.None;
            var itemListView = new ItemListView(new List<Item>(), itemListViewSelection);

            Assert.AreEqual(itemListViewSelection, itemListView.ItemListViewSelection);
        }
    }
}
