using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using KellermanSoftware.CompareNetObjects;
using TheLongDarkItemMarker.Tests.Common;

namespace TheLongDarkItemMarker.FileSaving.Tests;

[TestClass]
[ExcludeFromCodeCoverage]
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


    #region Markers saving / loading

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
    public void GetMarkersFromJsonFileThrowsArgumentExceptionIfFileDoesNotExist()
    {
        jsonManager.GetMarkersFromJsonFile(jsonFilePath);
    }

    [TestMethod]
    public void GetMarkersFromJsonFileReturnsExpectedList()
    {
        File.WriteAllText(jsonFilePath, Constants.MarkersJsonString);

        var markersFromJsonFile = jsonManager.GetMarkersFromJsonFile(jsonFilePath);

        var compareLogic = new CompareLogic();
        Assert.IsTrue(compareLogic.Compare(markersFromJsonFile, DomainEntities.Markers).AreEqual);
    }

    #endregion


    #region Items loading

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void GetItemsFromJsonFileThrowsArgumentExceptionIfFileDoesNotExist()
    {
        jsonManager.GetMarkersFromJsonFile(jsonFilePath);
    }

    [TestMethod]
    public void GetItemsFromJsonFileReturnsExpectedList()
    {
        File.WriteAllText(jsonFilePath, Constants.ItemsJsonString);

        var itemsFromJsonFile = jsonManager.GetItemsFromJsonFile(jsonFilePath);

        var compareLogic = new CompareLogic();
        Assert.IsTrue(compareLogic.Compare(itemsFromJsonFile, DomainEntities.Items).AreEqual);
    }

    #endregion

    [TestCleanup]
    public void Cleanup()
    {
        if (File.Exists(jsonFilePath))
        {
            File.Delete(jsonFilePath);
        }
    }
}