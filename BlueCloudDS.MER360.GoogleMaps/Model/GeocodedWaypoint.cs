using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueCloudDS.MER360.GoogleMaps.Model.Maps
{
    public class GeocodedWaypoint
    {
        public GeocodedWaypoint()
        {
            Types = new List<string>();
        }

        [JsonProperty(propertyName: "geocoder_status")]
        public StatusCodes GeocoderStatus { get; set; }

        [JsonProperty(propertyName: "place_id")]
        public string PlaceId { get; set; }

        [JsonProperty(propertyName: "types")]
        public List<string> Types { get; set; }
    }
}
