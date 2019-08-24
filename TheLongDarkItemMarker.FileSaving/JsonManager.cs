using System;
using System.Collections.Generic;
using System.IO;
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

            var serializedVehicles = JsonConvert.SerializeObject(markers);
            File.WriteAllText(jsonFilePath, serializedVehicles);
        }

        public List<Marker> GetMarkersFromJsonFile(string jsonFilePath)
        {
            ValidateJsonFilePath(jsonFilePath);
            ThrowIfFileDoesNotExist(jsonFilePath);

            var fileContents = File.ReadAllText(jsonFilePath);
            var deserializedVehicles = JsonConvert.DeserializeObject<List<Marker>>(fileContents);

            return deserializedVehicles;
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
