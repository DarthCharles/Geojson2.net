using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geojson
{
    public class Geojson
    {
        public string type { get; set; }
        public List<Feature> features  { get; set; }
    }

  

    public class Feature {
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }



        
    }


    public class Geometry
    {
        public string type { get; set; }
        public List<List<Double>> coordinates { get; set; }

    }


    public class Properties
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