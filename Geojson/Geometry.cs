using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geojson
{
    class Geojson
    {
        public string type { get; set; }
        //public geometry geometry { get; set; }
        public List<geometry> geometries { get; set; }
        public properties properties { get; set; }
    }

  


    class geometry{

          public string type { get; set; }
          public List<List<Double>> coordinates { get; set; }


    }

    class geometries
    {

        public List<geometry> geometriesArray { get; set; }


    }


    class properties
	{
		public string name { get; set; }
	}
}


//{
//  "type": "Feature",
//  "geometry": {
//    "type": "Point",
//    "coordinates": [125.6, 10.1]
//  },
//  "properties": {
//    "name": "Dinagat Islands"
//  }
//}