using Newtonsoft.Json;
using System.Collections.Generic;

namespace BlueCloudDS.MER360.GoogleMaps.Model.Maps
{
    public class DirectionsResult
    {
        [JsonProperty(propertyName: "geocoded_waypoints")]
        public List<GeocodedWaypoint> GeocodedWaypoints { get; set; }

        [JsonProperty(propertyName: "routes")]
        public List<MapRoute> Routes { get; set; }

        public StatusCodes Status { get; set; }
    }
}
