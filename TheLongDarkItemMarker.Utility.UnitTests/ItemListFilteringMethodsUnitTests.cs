using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheLongDarkItemMarker.Domain.Entities;

namespace TheLongDarkItemMarker.Utility.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ItemListFilteringMethodsUnitTests
    {

        #region Filter by category tests

        [TestMethod]
        public void GetItemListFilteredByItemCategoryReturnsExpectedListForItemCategoryFireStarting()
        {
            var itemList = DomainEntities.ItemList2;
            var itemCategory = ItemCategory.FireStarting;
            var filteredList = ItemListFilteringMethods.GetItemListFilteredByItemCategory(itemList, itemCategory);

            Assert.IsTrue(filteredList.Count > 0);
            Assert.IsTrue(ItemListContainsItemsOfProvidedCategory(filteredList, itemCategory));
            Assert.IsTrue(ItemListContainsItemList(itemList, filteredList));
        }

        [TestMethod]
        public void GetItemListFilteredByItemCategoryReturnsExpectedListForItemCategoryFirstAid()
        {
            var itemList = DomainEntities.ItemList2;
            var itemCategory = ItemCategory.FirstAid;
            var filteredList = ItemListFilteringMethods.GetItemListFilteredByItemCategory(itemList, itemCategory);

            Assert.IsTrue(filteredList.Count > 0);
            Assert.IsTrue(ItemListContainsItemsOfProvidedCategory(filteredList, itemCategory));
            Assert.IsTrue(ItemListContainsItemList(itemList, filteredList));
        }

        [TestMethod]
        public void GetItemListFilteredByItemCategoryReturnsExpectedListForItemCategoryClothing()
        {
            var itemList = DomainEntities.ItemList2;
            var itemCategory = ItemCategory.Clothing;
            var filteredList = ItemListFilteringMethods.GetItemListFilteredByItemCategory(itemList, itemCategory);

            Assert.IsTrue(filteredList.Count > 0);
            Assert.IsTrue(ItemListContainsItemsOfProvidedCategory(filteredList, itemCategory));
            Assert.IsTrue(ItemListContainsItemList(itemList, filteredList));
        }

        [TestMethod]
        public void GetItemListFilteredByItemCategoryReturnsExpectedListForItemCategoryFoodAndDrink()
        {
            var itemList = DomainEntities.ItemList2;
            var itemCategory = ItemCategory.FoodAndDrink;
            var filteredList = ItemListFilteringMethods.GetItemListFilteredByItemCategory(itemList, itemCategory);

            Assert.IsTrue(filteredList.Count > 0);
            Assert.IsTrue(ItemListContainsItemsOfProvidedCategory(filteredList, itemCategory));
            Assert.IsTrue(ItemListContainsItemList(itemList, filteredList));
        }

        [TestMethod]
        public void GetItemListFilteredByItemCategoryReturnsExpectedListForItemCategoryTool()
        {
            var itemList = DomainEntities.ItemList2;
            var itemCategory = ItemCategory.Tool;
            var filteredList = ItemListFilteringMethods.GetItemListFilteredByItemCategory(itemList, itemCategory);

            Assert.IsTrue(filteredList.Count > 0);
            Assert.IsTrue(ItemListContainsItemsOfProvidedCategory(filteredList, itemCategory));
            Assert.IsTrue(ItemListContainsItemList(itemList, filteredList));
        }

        [TestMethod]
        public void GetItemListFilteredByItemCategoryReturnsExpectedListForItemCategoryMaterial()
        {
            var itemList = DomainEntities.ItemList2;
            var itemCategory = ItemCategory.Material;
            var filteredList = ItemListFilteringMethods.GetItemListFilteredByItemCategory(itemList, itemCategory);

            Assert.IsTrue(filteredList.Count > 0);
            Assert.IsTrue(ItemListContainsItemsOfProvidedCategory(filteredList, itemCategory));
            Assert.IsTrue(ItemListContainsItemList(itemList, filteredList));
        }

        [TestMethod]
        public void GetItemListFilteredByItemCategoryReturnsEmptyListIfThereAreNoItemsWithProvidedCategory()
        {
            var itemList = new List<Item> {DomainEntities.ItemClothing};
            var itemCategory = ItemCategory.Material;
            var filteredList = ItemListFilteringMethods.GetItemListFilteredByItemCategory(itemList, itemCategory);

            Assert.AreEqual(0, filteredList.Count);
        }

        #endregion


        #region Filter by name tests

        [TestMethod]
        public void GetItemListFilteredByNameReturnsExpectedListForPartOfNameProvided()
        {
            var itemList = DomainEntities.ItemList2;
            var stringToSearch = "drink";
            var filteredList = ItemListFilteringMethods.GetItemListFilteredByName(itemList, stringToSearch);

            Assert.IsTrue(filteredList.Count > 0);
            Assert.IsTrue(ItemListContainsItemsWithNameContainingProvidedString(filteredList, stringToSearch));
            Assert.IsTrue(ItemListContainsItemList(itemList, filteredList));
        }

        [TestMethod]
        public void GetItemListFilteredByNameReturnsExpectedListForPartOfNameProvidedRegardlessOfUpperOrLowerCase()
        {
            var itemList = DomainEntities.ItemList2;
            var stringToSearchUpper = "Fire";
            var filteredListUpper = ItemListFilteringMethods.GetItemListFilteredByName(itemList, stringToSearchUpper);

            Assert.IsTrue(filteredListUpper.Count > 0);
            Assert.IsTrue(ItemListContainsItemsWithNameContainingProvidedString(filteredListUpper, stringToSearchUpper));
            Assert.IsTrue(ItemListContainsItemList(itemList, filteredListUpper));

            var stringToSearchLower = "Fire";
            var filteredListLower = ItemListFilteringMethods.GetItemListFilteredByName(itemList, stringToSearchUpper);

            Assert.IsTrue(filteredListLower.Count > 0);
            Assert.IsTrue(ItemListContainsItemsWithNameContainingProvidedString(filteredListLower, stringToSearchLower));
            Assert.IsTrue(ItemListContainsItemList(itemList, filteredListLower));


            var compareLogic = new CompareLogic();
            Assert.IsTrue(compareLogic.Compare(filteredListUpper, filteredListLower).AreEqual);
        }

        [TestMethod]
        public void GetItemListFilteredByNameReturnsEmptyListForIfThereAreNoItemsContainingProvidedString()
        {
            var itemList = DomainEntities.ItemList2;
            var stringToSearch = "a string that shouldn't be contained in any of the item's names";
            var filteredList = ItemListFilteringMethods.GetItemListFilteredByName(itemList, stringToSearch);

            Assert.AreEqual(0, filteredList.Count);
        }

        #endregion


        private bool ItemListContainsItemsOfProvidedCategory(List<Item> itemList, ItemCategory itemCategory)
        {
            return itemList.All(x => x.ItemCategory == itemCategory);
        }

        private bool ItemListContainsItemsWithNameContainingProvidedString(List<Item> itemList, string providedString)
        {
            return itemList.All(x => x.Name.ToLower().Contains(providedString.ToLower()));
        }

        private bool ItemListContainsItemList(List<Item> itemList, List<Item> itemListToBeFound)
        {
            if (itemList.Count < itemListToBeFound.Count)
            {
                return false;
            }

            foreach (var itemToBeFound in itemListToBeFound)
            {
                if (!itemList.Contains(itemToBeFound))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
