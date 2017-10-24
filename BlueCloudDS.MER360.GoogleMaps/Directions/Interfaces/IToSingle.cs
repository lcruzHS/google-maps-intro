using BlueCloudDS.MER360.GoogleMaps.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueCloudDS.MER360.GoogleMaps.Directions.Interfaces
{
    public interface IToSingle
    {
        /// <summary>
        /// Sets the final destination GPS point.
        /// </summary>
        /// <param name="point">Global GPS coordinates.</param>
        /// <returns>An <see cref="IDirections"/> refence.</returns>
        IEnd To(Point point);

        /// <summary>
        /// Sets the final destination address.
        /// </summary>
        /// <param name="address">The address for the destination.</param>
        /// <returns>An <see cref="IDirections"/> reference.</returns>
        IEnd To(Address address);
    }
}
