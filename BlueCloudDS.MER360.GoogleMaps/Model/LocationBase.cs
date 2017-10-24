using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueCloudDS.MER360.GoogleMaps.Model
{
    public abstract class LocationBase: ICloneable
    {
        public abstract override string ToString();

        public abstract object Clone();

    }
}
