using System.Drawing;

namespace TheLongDarkItemMarker.Settings;

public static class Settings
{
    private static readonly Dictionary<string, Image> ItemImages = new();

    static Settings()
    {
        const string resourcesFolder = "Resources";

        if (!Directory.Exists(resourcesFolder))
        {
            throw new Exception("Could not find resources folder");
        }

        // TODO: Improve file structure
        var resourceFiles = Directory.GetFiles(resourcesFolder);

        foreach (var resourceFile in resourceFiles)
        {
            var resourceName = Path.GetFileNameWithoutExtension(resourceFile);

            if (resourceFile.Contains("item"))
            {
                ItemImages.Add(resourceName, Image.FromFile(resourceFile));
            }
        }
    }

    public static Image GetMapImageOrDefault(string mapImageName, Image defaultImage = null)
    {
        var filepath = Path.Combine("Resources", $"{mapImageName}.jpg");

        if (File.Exists(filepath))
        {
            return Image.FromFile(filepath);
        }

        return defaultImage ?? new Bitmap(512, 512);
    }

    public static Image GetItemImageOrDefault(string itemImageName, Image defaultImage = null)
    {
        if (ItemImages.TryGetValue(itemImageName, out var image))
        {
            return image;
        }

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