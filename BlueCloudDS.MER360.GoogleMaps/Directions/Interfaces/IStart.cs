using BlueCloudDS.MER360.GoogleMaps.Interfaces;

namespace BlueCloudDS.MER360.GoogleMaps.Directions.Interfaces
{
    public interface IStart
    {
        /// <summary>
        /// Starts the process to specify the starting point/address to request directions.
        /// </summary>
        /// <param name="travelMode">Optional. The travel mode.</param>
        /// <returns>The <see cref="IFrom"/> reference.</returns>
        IFrom Start(TravelModes travelMode = TravelModes.Unknown);

        /// <summary>
        /// Starts the process to specify the point/address to a location.
        /// </summary>
        /// <param name="travelMode">Optional. The travel mode.</param>
        /// <returns>The <see cref="ITo"/> reference.</returns>
        IToSingle Single(TravelModes travelMode = TravelModes.Unknown);
    }
}
