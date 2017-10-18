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
    public class WebHelper
    {
        private const string API_KEY = "key";

        public static void GetDirections(DirectionRequest request)
        {
            var uri = new Uri("https://maps.googleapis.com/maps/api/directions/json");
            //?origin=Disneyland&destination=Universal+Studios+Hollywood4&key=YOUR_API_KEY);

            var uriBuilder = new UriBuilder(uri);            

           NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

           // queryString.Add(DIRECTIONS_ORIGIN, "sss");
            queryString["key2"] = "value2";

            //return queryString.ToString();

            //uriBuilder





            HttpWebRequest http = (HttpWebRequest)WebRequest.Create("http://example.com");
            WebResponse response = http.GetResponse();

            StreamReader sr = new StreamReader(response.GetResponseStream());
            string content = sr.ReadToEnd();
        }
    }
}
