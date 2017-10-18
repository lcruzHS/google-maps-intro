using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueCloudDS.MER360.GoogleMaps.Model
{
    public sealed class Point : LocationBase
    {
        public Point(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        #region Properties

        [JsonProperty(propertyName: "lng")]
        public double Longitude { get; private set; }

        [JsonProperty(propertyName: "lat")]
        public double Latitude { get; private set; }

        #endregion Properties

        public override string ToString()
        {
            return string.Format("{0},{1}", Latitude, Longitude);
        }
    }
}
