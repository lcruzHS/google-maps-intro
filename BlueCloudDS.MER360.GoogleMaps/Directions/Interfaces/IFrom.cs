using BlueCloudDS.MER360.GoogleMaps.Model;

namespace BlueCloudDS.MER360.GoogleMaps.Directions.Interfaces
{
    public interface IFrom
    {
        /// <summary>
        /// Sets the starting GPS point.
        /// </summary>
        /// <param name="point">Global GPS coordinates for start location.</param>
        /// <returns>An <see cref="ITo"/> reference.</returns>
        IThenTo From(Point point);

        /// <summary>
        /// Sets the starting address.
        /// </summary>
        /// <param name="address">The addess for start location.</param>
        /// <returns></returns>
        IThenTo From(Address address);
    }
}
