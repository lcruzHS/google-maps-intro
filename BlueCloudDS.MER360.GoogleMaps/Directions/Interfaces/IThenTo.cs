using BlueCloudDS.MER360.GoogleMaps.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueCloudDS.MER360.GoogleMaps.Directions.Interfaces
{
    public interface IThenTo: ITo
    {
        /// <summary>
        /// Sets the next destination GPS point.
        /// </summary>
        /// <param name="point">Global GPS coordinates.</param>
        /// <returns>An <see cref="IDirections"/> refence.</returns>
        IThenTo Then(Point point);

        /// <summary>
        /// Sets the next destination address.
        /// </summary>
        /// <param name="address">The address for the destination.</param>
        /// <returns>An <see cref="IDirections"/> reference.</returns>
        IThenTo Then(Address address);
    }
}
