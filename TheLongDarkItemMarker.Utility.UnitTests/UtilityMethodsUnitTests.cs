using System.Diagnostics.CodeAnalysis;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheLongDarkItemMarker.Utility.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class UtilityMethodsUnitTests
    {

        #region GetZoomedImage tests

        [TestMethod]
        public void GetZoomedImageReturnsImageWithExpectedSize1()
        {
            var zoomedImage = UtilityMethods.GetZoomedImage(Constants.Image, Constants.ZoomFactor1);

            Assert.AreEqual(Constants.ImageSizeAfterZoomFactor1, zoomedImage.Size);
        }

        [TestMethod]
        public void GetZoomedImageReturnsImageWithExpectedSize2()
        {
            var zoomedImage = UtilityMethods.GetZoomedImage(Constants.Image, Constants.ZoomFactor2);

            Assert.AreEqual(Constants.ImageSizeAfterZoomFactor2, zoomedImage.Size);
        }

        #endregion


        #region GetZoomFactorForImageToFitInSpecifiedSize tests

        [TestMethod]
        public void GetZoomFactorForImageToFitInSpecifiedSizeReturnsExpectedZoomFactor1()
        {
            var zoomFactor = UtilityMethods.GetZoomFactorForImageToFitInSpecifiedSize(Constants.Image, Constants.ImageSizeAfterZoomFactor1);

            Assert.AreEqual(Constants.ZoomFactor1, zoomFactor);
        }

        [TestMethod]
        public void GetZoomFactorForImageToFitInSpecifiedSizeReturnsExpectedZoomFactor2()
        {
            var zoomFactor = UtilityMethods.GetZoomFactorForImageToFitInSpecifiedSize(Constants.Image, Constants.ImageSizeAfterZoomFactor2);

            Assert.AreEqual(Constants.ZoomFactor2, zoomFactor);
        }

        #endregion


        #region GetItemClone tests

        [TestMethod]
        public void GetItemCloneReturnsExpectedItemForItemSimple()
        {
            var item = DomainEntities.ItemSimple;

            var clonedItem = UtilityMethods.GetItemClone(item);

            var compareLogic = new CompareLogic();
            Assert.AreNotEqual(item, clonedItem);
            Assert.IsTrue(compareLogic.Compare(item, clonedItem).AreEqual);
        }

        [TestMethod]
        public void GetItemCloneReturnsExpectedItemForItemWithCondition()
        {
            var item = DomainEntities.ItemWithCondition;

            var clonedItem = UtilityMethods.GetItemClone(item);

            var compareLogic = new CompareLogic();
            Assert.AreNotEqual(item, clonedItem);
            Assert.IsTrue(compareLogic.Compare(item, clonedItem).AreEqual);
        }

        [TestMethod]
        public void GetItemCloneReturnsExpectedItemForItemWithQuantity()
        {
            var item = DomainEntities.ItemWithQuantity;

            var clonedItem = UtilityMethods.GetItemClone(item);

            var compareLogic = new CompareLogic();
            Assert.AreNotEqual(item, clonedItem);
            Assert.IsTrue(compareLogic.Compare(item, clonedItem).AreEqual);
        }

        [TestMethod]
        public void GetItemCloneReturnsExpectedItemForItemWithConditionAndQuantity()
        {
            var item = DomainEntities.ItemWithConditionAndQuantity;

            var clonedItem = UtilityMethods.GetItemClone(item);

            var compareLogic = new CompareLogic();
            Assert.AreNotEqual(item, clonedItem);
            Assert.IsTrue(compareLogic.Compare(item, clonedItem).AreEqual);
        }

        #endregion


        #region GetItemFromListSimilarToProvidedItem tests

        [TestMethod]
        public void GetItemFromListSimilarToProvidedItemReturnsExpectedItemForItemSimple()
        {
            var itemList = DomainEntities.ItemList1;
            var itemToSearch = DomainEntities.ItemSimple;

            var returnedItem = UtilityMethods.GetItemFromListSimilarToProvidedItem(itemList, itemToSearch);

            var compareLogic = new CompareLogic();
            Assert.IsTrue(itemList.Contains(returnedItem));
            Assert.IsTrue(compareLogic.Compare(itemToSearch, returnedItem).AreEqual);
        }

        [TestMethod]
        public void GetItemFromListSimilarToProvidedItemReturnsExpectedItemForItemWithCondition()
        {
            var itemList = DomainEntities.ItemList1;
            var itemToSearch = DomainEntities.ItemWithCondition;

            var returnedItem = UtilityMethods.GetItemFromListSimilarToProvidedItem(itemList, itemToSearch);

            var compareLogic = new CompareLogic();
            Assert.IsTrue(itemList.Contains(returnedItem));
            Assert.IsTrue(compareLogic.Compare(itemToSearch, returnedItem).AreEqual);
        }

        [TestMethod]
        public void GetItemFromListSimilarToProvidedItemReturnsExpectedItemForItemWithQuantity()
        {
            var itemList = DomainEntities.ItemList1;
            var itemToSearch = DomainEntities.ItemWithQuantity;

            var returnedItem = UtilityMethods.GetItemFromListSimilarToProvidedItem(itemList, itemToSearch);

            var compareLogic = new CompareLogic();
            Assert.IsTrue(itemList.Contains(returnedItem));
            Assert.IsTrue(compareLogic.Compare(itemToSearch, returnedItem).AreEqual);
        }

        [TestMethod]
        public void GetItemFromListSimilarToProvidedItemReturnsExpectedItemForItemWithConditionAndQuantity()
        {
            var itemList = DomainEntities.ItemList1;
            var itemToSearch = DomainEntities.ItemWithConditionAndQuantity;

            var returnedItem = UtilityMethods.GetItemFromListSimilarToProvidedItem(itemList, itemToSearch);

            var compareLogic = new CompareLogic();
            Assert.IsTrue(itemList.Contains(returnedItem));
            Assert.IsTrue(compareLogic.Compare(itemToSearch, returnedItem).AreEqual);
        }

        #endregion
    }
}
