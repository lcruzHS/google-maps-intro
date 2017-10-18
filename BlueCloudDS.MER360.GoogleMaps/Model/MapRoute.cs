using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueCloudDS.MER360.GoogleMaps.Model.Maps
{
    public class MapRoute
    {
        public MapRoute()
        {
            Legs = new List<MapRouteLeg>();
        }

        public MapRouteBound Bounds { get; set; }

        public List<MapRouteLeg> Legs { get; set; }

        public string Summary { get; set; }

        [JsonProperty(propertyName: "waypoint_order")]
        public List<int> WaypointOrder { get; set; }
    }
}
