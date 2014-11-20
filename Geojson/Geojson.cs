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
        public List<Feature> features { get; set; }
    }

    public class Feature
    {
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Object properties { get; set; }
    }


    public class Geometry
    {
        public string type { get; set; }
        public object coordinates { get; set; }

    }


    public class PolylineProperties
    {
        public string FeatureType { get; set; }
        public string idRecorrido { get; set; }
        public string Color { get; set; }

    }

    public class PolygonProperties
    {
        public string FeatureType { get; set; }
        public string idGeocerca { get; set; }
        public string Nombre { get; set; }
        public string Color { get; set; }

    }

    public class MarkerProperties
    {
        public string FeatureType { get; set; }
        public string Velocidad { get; set; }
        public string Fecha { get; set; }

    }


}
