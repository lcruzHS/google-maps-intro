using BlueCloudDS.MER360.GoogleMaps.Interfaces;
using BlueCloudDS.MER360.GoogleMaps.Model;

namespace BlueCloudDS.MER360.GoogleMaps.Directions.Interfaces
{
    public interface IEnd
    {
        /// <summary>
        /// Ends the direction processs.
        /// </summary>
        /// <param name="travelMode">Optional. Overrides the initialy specified travel mode.</param>
        /// <returns>The <see cref="DirectionRequest"/> reference with the start and end locations.</returns>
        ApiMapsConnection End(TravelModes travelMode = TravelModes.Unknown);
    }
}
