using System;
using BlueCloudDS.MER360.GoogleMaps.Interfaces;
using BlueCloudDS.MER360.GoogleMaps.Directions.Interfaces;
using BlueCloudDS.MER360.GoogleMaps.Model;
using System.Collections.Generic;
using BlueCloudDS.MER360.GoogleMaps;
using BlueCloudDS.MER360.GoogleMaps.Directions;

namespace BlueCloudDS.MER360.GoogleMaps
{
    public sealed class DirectionsService : IStart, IFrom, ITo, IThenTo, IEnd
    {
        List<LocationBase> _locations;

        public DirectionsService()
        {
            _locations = new List<LocationBase>();
        }

        #region Properties

        public TravelModes TravelMode { get; private set; }

        #endregion //Properties

        #region IStart members    

        public IFrom Start(TravelModes travelMode = TravelModes.Unknown)
        {
            TravelMode = travelMode;

            return this;
        }

        public ITo Single(TravelModes travelMode = TravelModes.Unknown)
        {
            TravelMode = travelMode;

            return this;
        }

        #endregion //IStart members

        #region IFrom members

        IThenTo IFrom.From(Address address)
        {
            if (address == null) throw new ArgumentNullException("address");

            _locations.Clear();
            _locations.Add(address);

            return this;
        }

        IThenTo IFrom.From(Point point)
        {
            if (point == null) throw new ArgumentNullException("point");

            _locations.Clear();
            _locations.Add(point);

            return this;
        }

        #endregion //IFrom members

        #region ITo members

        IThenTo IThenTo.Then(Address address)
        {
            if (address == null) throw new ArgumentNullException("address");

            _locations.Add(address);

            return this;
        }

        IThenTo IThenTo.Then(Point point)
        {
            if (point == null) throw new ArgumentNullException("point");

            _locations.Add(point);

            return this;
        }

        IEnd ITo.To(Address address)
        {
            if (address == null) throw new ArgumentNullException("address");

            _locations.Add(address);

            return this;
        }

        IEnd ITo.To(Point point)
        {
            if (point == null) throw new ArgumentNullException("point");

            _locations.Add(point);

            return this;
        }
        #endregion //ITo members

        #region IEnd members

        ApiMapsConnection IEnd.End(TravelModes travelMode)
        {
            if (travelMode != TravelModes.Unknown)
                TravelMode = travelMode;            

            var dirMapsConn = new DirectionsMapsConnection();
            dirMapsConn.SetTheRequest(new DirectionRequest(_locations.ToArray(), TravelMode));

            return dirMapsConn;
        }

        #endregion //IEnd members
    }
}
