using BlueCloudDS.MER360.GoogleMaps.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BlueCloudDS.MER360.GoogleMaps.Helpers
{
    public static class ConvertionHelpers
    {
        public static double MetersToMiles(double meters)
        {
            return meters / Constants.ConvertionUnits.METERS_PER_MILE;
        }

        public static double MilesToMeters(double miles)
        {
            return miles * Constants.ConvertionUnits.METERS_PER_MILE;
        }

        public static double MilesToKilometers(double miles)
        {
            return miles * Constants.ConvertionUnits.KILOMETERS_PER_MILE;
        }

        public static double KilometersToMiles(double kilometers)
        {
            return kilometers / Constants.ConvertionUnits.KILOMETERS_PER_MILE;
        }

        public static double MetersToKilometers(double meters)
        {
            return meters / Constants.ConvertionUnits.METERS_PER_KILOMETER;
        }

        public static double KilometersToMeters(double kilometers)
        {
            return kilometers *  Constants.ConvertionUnits.METERS_PER_KILOMETER;
        }
    }
}
