using BlueCloudDS.MER360.GoogleMaps.Model;

namespace BlueCloudDS.MER360.GoogleMaps.Directions.Interfaces
{
    public interface ITo
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
