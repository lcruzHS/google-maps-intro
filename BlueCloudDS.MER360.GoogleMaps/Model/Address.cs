using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueCloudDS.MER360.GoogleMaps.Model
{
    public sealed class Address: LocationBase
    {
        public Address(string street = null, string city = null, string zip = null, string state = null, string country = null)
        {
            var atLeastOne = street ?? city ?? zip ?? state ?? country;
            if (atLeastOne == null) throw new ArgumentNullException("Must provide at least one: Street or City or Zip or State or Country.");

            Street = street;
            City = city;
            Zip = zip;
            State = state;
            Country = country;
        }

        #region Properties
        public string Street { get; private set; }

        public string City { get; private set; }

        public string Zip { get; private set; }

        public string State { get; private set; }

        public string Country { get; private set; }
        #endregion Properties

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", Street, City, Zip, State, Country);
        }
    }
}
