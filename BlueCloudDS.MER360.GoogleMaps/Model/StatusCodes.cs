using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueCloudDS.MER360.GoogleMaps.Model.Maps
{
    public enum StatusCodes
    {
        OK,
        NOT_FOUND,
        ZERO_RESULTS,
        MAX_WAYPOINTS_EXCEEDED,
        MAX_ROUTE_LENGTH_EXCEEDED,
        INVALID_REQUEST,
        OVER_QUERY_LIMIT,
        REQUEST_DENIED,
        UNKNOWN_ERROR
    }
}
