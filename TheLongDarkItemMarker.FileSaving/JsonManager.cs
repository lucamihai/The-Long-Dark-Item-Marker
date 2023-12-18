using Newtonsoft.Json;
using TheLongDarkItemMarker.Domain.Entities;

namespace TheLongDarkItemMarker.FileSaving
{
    public class JsonManager
    {
        public void SaveMarkersToJsonFile(List<Marker> markers, string jsonFilePath)
        {
            ValidateMarkerList(markers);
            ValidateJsonFilePath(jsonFilePath);

            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All, Formatting = Formatting.Indented};
            var serializedMarkers = JsonConvert.SerializeObject(markers, settings);
            File.WriteAllText(jsonFilePath, serializedMarkers);
        }

        public List<Marker> GetMarkersFromJsonFile(string jsonFilePath)
        {
            ValidateJsonFilePath(jsonFilePath);
            ThrowIfFileDoesNotExist(jsonFilePath);

            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            var fileContents = File.ReadAllText(jsonFilePath);
            var deserializedMarkers = JsonConvert.DeserializeObject<List<Marker>>(fileContents, settings);

            return deserializedMarkers;
        }

        public List<Item> GetItemsFromJsonFile(string jsonFilePath)
        {
            ValidateJsonFilePath(jsonFilePath);
            ThrowIfFileDoesNotExist(jsonFilePath);

            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            var fileContents = File.ReadAllText(jsonFilePath);
            var deserializedItems = JsonConvert.DeserializeObject<List<Item>>(fileContents, settings);

            return deserializedItems;
        }

        private void ValidateMarkerList(List<Marker> markers)
        {
            if (markers == null)
            {
                throw new ArgumentNullException();
            }
        }

        private void ValidateJsonFilePath(string jsonFilePath)
        {
            if (jsonFilePath == null)
            {
                throw new ArgumentNullException();
            }
        }

        private void ThrowIfFileDoesNotExist(string jsonFilePath)
        {
            if (!File.Exists(jsonFilePath))
            {
                throw new ArgumentException($"{jsonFilePath} does not exist");
            }
        }
    }
}
