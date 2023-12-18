using System.Drawing;

namespace TheLongDarkItemMarker.Settings;

public static class Settings
{
    private static readonly Dictionary<string, Image> MapImages = new();
    private static readonly Dictionary<string, Image> ItemImages = new();

    static Settings()
    {
        const string resourcesFolder = "Resources";

        if (!Directory.Exists(resourcesFolder))
        {
            throw new Exception("Could not find resources folder");
        }

        // TODO: Improve file structure
        //var resourceFiles = Directory.GetFiles(resourcesFolder);
        //var mapImageFiles = resourceFiles.Where(x => !x.StartsWith("item")).Distinct();
        //var itemImageFiles = resourceFiles.Where(x => x.StartsWith("item")).Distinct();

        //foreach (var resourceFile in resourceFiles)
        //{
        //    var name = Path.GetFileNameWithoutExtension(resourceFile);

        //    if (resourceFile.Contains("item"))
        //    {

        //    }
        //    else
        //    {

        //    }
        //}

        //foreach (var mapImageFile in mapImageFiles)
        //{
        //    var mapName = Path.GetFileName(mapImageFile);
        //    MapImages.Add(mapName, Image.FromFile(mapImageFile));
        //}

        //foreach (var itemImageFile in itemImageFiles)
        //{
        //    var itemName = Path.GetFileName(itemImageFile);
        //    ItemImages.Add(itemImageFile, Image.FromFile(itemImageFile));
        //}
    }

    public static Image GetMapImageOrDefault(string mapImageName, Image defaultImage = null)
    {
        var filepath = Path.Combine("Resources", $"{mapImageName}.png");

        if (File.Exists($"Resources\\{mapImageName}.png"))
        {
            return Image.FromFile(filepath);
        }

        //if (MapImages.TryGetValue(mapImageName, out var image))
        //{
        //    return image;
        //}

        return defaultImage ?? new Bitmap(512, 512);
    }

    public static Image GetItemImageOrDefault(string itemImageName, Image defaultImage = null)
    {
        var filepath = Path.Combine("Resources", $"{itemImageName}.png");

        if (File.Exists($"Resources\\{itemImageName}.png"))
        {
            return Image.FromFile(filepath);
        }

        //if (ItemImages.TryGetValue(itemImageName, out var image))
        //{
        //    return image;
        //}

        return defaultImage ?? new Bitmap(512, 512);
    }

    public const string About =
        @"The Long Dark Item Marker is an application made purely for fun purposes.
I did not earn any money making this, and I'm not making any money if this application is used.

The Long Dark is a survival game developed by Hinterland Games (https://hinterlandgames.com).
The creators of the maps I've used can be seen in each map.

More details can be found on the Github page of the project: https://github.com/lucamihai/The-Long-Dark-Item-Marker
";

    // TODO: Currently not working, investigate why
    public const string HelpWebPageUrl = "https://lucamihai.github.io/The-Long-Dark-Item-Marker-Wep-Page/";

}