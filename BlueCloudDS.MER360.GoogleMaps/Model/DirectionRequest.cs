using BlueCloudDS.MER360.GoogleMaps.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueCloudDS.MER360.GoogleMaps.Model
{
    public sealed class DirectionRequest
    {
        /// <summary>
        /// Creates a new instance of <see cref="DirectionRequest"/>
        /// </summary>
        /// <param name="locations">The lis of locatios for which to find route.</param>
        /// <param name="travelMode">The travel mode (i.e. car, transit) selected to find the route.</param>
        public DirectionRequest(IEnumerable<LocationBase> locations, TravelModes travelMode = TravelModes.Unknown)
        {
            Locations = new List<LocationBase>(locations);
            TravelMode = travelMode;
        }

        /// <summary>
        /// Gets the list of locations Point/Address.
        /// </summary>
        public List<LocationBase> Locations { get; private set; }

        /// <summary>
        /// Gets the Travel Mode prefered, if any, to find a route for the specificed locations.
        /// </summary>
        public TravelModes TravelMode { get; private set; }

        /// <summary>
        /// Returns a string representation of the current request.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (Locations == null || Locations.Count == 0) return string.Empty;

            var builder = new StringBuilder();
            int minIndex = 0;
            int maxIndex = Locations.Count - 1;

            foreach (var loc in Locations)
            {
                if (Locations.IndexOf(loc) == minIndex)
                    builder.Append("Starting from -> ");
                else if (Locations.IndexOf(loc) == maxIndex)
                    builder.AppendLine("Finally to -> ");
                else
                    builder.AppendLine("Then to -> ");

                builder.Append(loc.GetType().Name + ": ");
                builder.Append(loc.ToString());
            }

            builder.AppendLine("Travel mode: ");
            builder.Append(Enum.GetName(typeof(TravelModes), TravelMode.ToString()));

            return builder.ToString();
        }
    }
}
