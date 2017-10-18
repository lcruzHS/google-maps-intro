using BlueCloudDS.MER360.GoogleMaps.Interfaces;
using Newtonsoft.Json;

namespace BlueCloudDS.MER360.GoogleMaps.Model.Maps
{
    public class MapRouteLegStep
    {
        public MapRouteDistance Distance { get; set; }

        public MapRouteDuration Duration { get; set; }

        [JsonProperty(propertyName: "start_location")]
        public Point StartLocation { get; set; }

        [JsonProperty(propertyName: "end_location")]
        public Point EndLocation { get; set; }

        [JsonProperty(propertyName: "travel_mode")]
        public TravelModes TravelMode { get; set; }

        public string Maneuver { get; set; }
    }
}