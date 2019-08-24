using System;
using System.IO;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheLongDarkItemMarker.UnitTests.Common;
using TheLongDarkItemMarker.Utility.UnitTests;

namespace TheLongDarkItemMarker.FileSaving.UnitTests
{
    [TestClass]
    public class JsonManagerUnitTests
    {
        private JsonManager jsonManager;
        private string jsonFilePath;

        [TestInitialize]
        public void Setup()
        {
            jsonManager = new JsonManager();
            jsonFilePath = $"{Environment.CurrentDirectory}\\jsonMarkersTest.json";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SaveMarkersToJsonFileThrowsArgumentNullExceptionForNullMarkerList()
        {
            jsonManager.SaveMarkersToJsonFile(null, jsonFilePath);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SaveMarkersToJsonFileThrowsArgumentNullExceptionForNullJsonFilePath()
        {
            jsonManager.SaveMarkersToJsonFile(DomainEntities.Markers, null);
        }

        [TestMethod]
        public void SaveMarkersToJsonFileCreatesFileIfItDoesNotExist()
        {
            Assert.IsFalse(File.Exists(jsonFilePath));

            jsonManager.SaveMarkersToJsonFile(DomainEntities.Markers, jsonFilePath);

            Assert.IsTrue(File.Exists(jsonFilePath));
        }

        [TestMethod]
        public void SaveMarkersToJsonFileWillOverwriteExistingFile()
        {
            var fileInitialContents = "someContents";
            File.WriteAllText(jsonFilePath, fileInitialContents);

            jsonManager.SaveMarkersToJsonFile(DomainEntities.Markers, jsonFilePath);

            var fileCurrentContents = File.ReadAllText(jsonFilePath);
            Assert.AreNotEqual(fileCurrentContents, fileInitialContents);
        }

        [TestMethod]
        public void SaveMarkersToJsonFileWritesExpectedStringToFile()
        {
            jsonManager.SaveMarkersToJsonFile(DomainEntities.Markers, jsonFilePath);

            var fileContents = File.ReadAllText(jsonFilePath);
            Assert.AreEqual(Constants.MarkersJsonString, fileContents);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ReadVehiclesFromJsonFileThrowsArgumentExceptionIfFileDoesNotExist()
        {
            jsonManager.GetMarkersFromJsonFile(jsonFilePath);
        }

        [TestMethod]
        public void ReadVehiclesFromJsonFileReturnsExpectedList()
        {
            File.WriteAllText(jsonFilePath, Constants.MarkersJsonString);

            var vehiclesFromJson = jsonManager.GetMarkersFromJsonFile(jsonFilePath);

            var compareLogic = new CompareLogic();
            Assert.IsTrue(compareLogic.Compare(vehiclesFromJson, DomainEntities.Markers).AreEqual);
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(jsonFilePath))
            {
                File.Delete(jsonFilePath);
            }
        }
    }
}
