using BlueCloudDS.MER360.GoogleMaps.Model;
using BlueCloudDS.MER360.GoogleMaps.Model.Maps;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueCloudDS.MER360.GoogleMaps.Directions
{
    public class DirectionsMapsConnection: ApiMapsConnection
    {
        private const string DIRECTIONS_ORIGIN = "origin";
        private const string DIRECTIONS_DESTINATION = "destination";
        private const string DIRECTIONS_WAYPOINTS = "waypoints";

        public DirectionsMapsConnection()
            : base(Properties.Settings.Default.Google_Maps_Directions_Api_Url)
        {
        }

        public void SetTheRequest(DirectionRequest request)
        {
            var wayPointsBuilder = new List<string>();
            Parameters.Clear();
            foreach(var item in request.Locations)
            {
                if (request.Locations.IndexOf(item) == 0)
                    Parameters.Add(DIRECTIONS_ORIGIN, item.ToString());
                else if (request.Locations.IndexOf(item) == (request.Locations.Count - 1))
                    Parameters.Add(DIRECTIONS_DESTINATION, item.ToString());
                else
                {
                    wayPointsBuilder.Add(item.ToString());
                }

            }
            if (wayPointsBuilder.Count > 0)
            {
                Parameters.Add(DIRECTIONS_WAYPOINTS, string.Join("|", wayPointsBuilder.ToArray()));
            }
        }

        public override T GetDirections<T>()
        {
            try
            {
                var str = GetText();

                var result = JsonConvert.DeserializeObject<DirectionsResult>(str);

                return result as T;
            }
            catch (Exception ex)
            {
                //TODO: Log error here.
                throw new ApplicationException("An error occurred trying to get directions for a set of locations.", ex);
            }
        }

        public override Task<T> GetDirectionsAsync<T>()
        {
            return Task.Factory.StartNew<T>(() => GetDirections<T>());
        }
    }
}
