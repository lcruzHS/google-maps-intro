using BlueCloudDS.MER360.GoogleMaps.Directions;
using BlueCloudDS.MER360.GoogleMaps.Model;
using BlueCloudDS.MER360.GoogleMaps.Model.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueCloudDS.MER360.GoogleMaps.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var dirService = new DirectionsService();

            var conn = dirService
                 .Start()
                 .From(new Address("HealthSTAR Education Center"))
                 .To(new Address("HealthSTAR Education Center"))
                 .End(Interfaces.TravelModes.Walking);


            //var conn = dirService
            //    .Start()
            //    //.From(new Point(40.730713, -73.994794))
            //    .From(new Address("HealthSTAR Education Center"))
            //    //.From(new Address("07430")) 
            //    .Then(new Point(40.884822, -74.044930))               
            //    //.Then(new Address(null, "Mahwah", null, "NJ", null))
            //    .To(new Address(null, "West New York", null, "NJ", null))
            //    .End(Interfaces.TravelModes.Walking);

            //var str = conn.GetText();

            //var result =  Newtonsoft.Json.JsonConvert.DeserializeObject<DirectionsResult>(str);

            var result = conn.GetDirections<DirectionsResult>();


            global::System.Console.WriteLine("Press any key to finish...");
            global::System.Console.ReadKey();
        }
    }
}
