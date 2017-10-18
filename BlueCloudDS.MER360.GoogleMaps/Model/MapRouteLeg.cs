using Newtonsoft.Json;
using System.Collections.Generic;

namespace BlueCloudDS.MER360.GoogleMaps.Model.Maps
{
    public class MapRouteLeg
    {
        public MapRouteDistance Distance { get; set; }

        public MapRouteDuration Duration { get; set; }

        [JsonProperty(propertyName: "start_address")]
        public string StartAddress { get; set; }

        [JsonProperty(propertyName: "start_location")]
        public Point StartLocation { get; set; }

        [JsonProperty(propertyName: "end_address")]
        public string EndAddress { get; set; }

        [JsonProperty(propertyName: "end_location")]
        public Point EndLocation { get; set; }

        public List<MapRouteLegStep> Steps { get; set; }

    }
}