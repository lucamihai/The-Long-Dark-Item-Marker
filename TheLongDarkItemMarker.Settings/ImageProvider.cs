using System.Drawing;

namespace TheLongDarkItemMarker.Settings;

public static class ImageProvider
{
    private static readonly Dictionary<string, Image> ItemImages = new();

    static ImageProvider()
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
}