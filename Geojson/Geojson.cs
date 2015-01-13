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

        public Geojson(List<LatLng> Coordinates, string Type)
        {
            this.type = "FeatureCollection";

            List<Feature> Features = new List<Feature>();
            List<List<Double>> LineCoordinates = new List<List<double>>();

            switch (Type)
            {
                case "Point":

                    foreach (LatLng latlng in Coordinates)
                    {

                        Feature tempFeature = new Feature();
                        tempFeature.type = "Feature";
                        tempFeature.geometry = new Geometry
                        {
                            type = "Point",
                            coordinates = new List<double>(){
                                  latlng.lng,
                                  latlng.lat
                            }
                        };

                        tempFeature.properties = new PointProperties()
                        {
                            FeatureType = "Point",
                            Lat = latlng.lat,
                            Lng = latlng.lng
                        };

                        Features.Add(tempFeature);

                    }

                    this.features = Features;

                    break;

                case "Polygon":

                    List<List<List<Double>>> PolygonContainer = new List<List<List<Double>>>();

                    foreach (LatLng latlng in Coordinates)
                    {

                        List<double> lista = new List<double>(){
                              latlng.lng,
                              latlng.lat
                         };

                        LineCoordinates.Add(lista);

                    }

                    PolygonContainer.Add(LineCoordinates);

                    Feature polygon = new Feature();
                    polygon.type = "Feature";

                    polygon.geometry = new Geometry
                    {
                        type = "Polygon",
                        coordinates = PolygonContainer
                    };

                    polygon.properties = new PolygonProperties()
                    {
                        FeatureType = "Polygon",
                        Color = "#3289c7"
                    };


                    Features.Add(polygon);

                    this.features = Features;

                    break;

                case "LineString":

                    foreach (LatLng latlng in Coordinates)
                    {

                        List<double> Points = new List<double>(){
                            latlng.lng,
                            latlng.lat
                          };

                        LineCoordinates.Add(Points);
                    }

                    Feature linea = new Feature();
                    linea.type = "Feature";

                    linea.geometry = new Geometry
                    {
                        type = "LineString",
                        coordinates = LineCoordinates
                    };

                    linea.properties = new PolylineProperties()
                    {
                        FeatureType = "LineString",
                        Color = "#3289c7"

                    };
                    Features.Add(linea);
                    this.features = Features;

                    break;

                default:
                    this.features = new List<Feature>();
                    break;
            }

        }

        public Geojson(List<LatLng> Coordinates, Object GeojsonProperties, string Type)
        {
            this.type = "FeatureCollection";

            List<Feature> Features = new List<Feature>();
            List<List<Double>> LineCoordinates = new List<List<double>>();

            switch (Type)
            {
                case "Point":

                    foreach (LatLng latlng in Coordinates)
                    {

                        Feature tempFeature = new Feature();
                        tempFeature.type = "Feature";
                        tempFeature.geometry = new Geometry
                        {
                            type = "Point",
                            coordinates = new List<double>(){
                                  latlng.lng,
                                  latlng.lat
                            }
                        };

                        tempFeature.properties = GeojsonProperties;

                        Features.Add(tempFeature);

                    }

                    this.features = Features;

                    break;

                case "Polygon":

                    List<List<List<Double>>> PolygonContainer = new List<List<List<Double>>>();

                    foreach (LatLng latlng in Coordinates)
                    {

                        List<double> lista = new List<double>(){
                              latlng.lng,
                              latlng.lat
                         };

                        LineCoordinates.Add(lista);

                    }

                    PolygonContainer.Add(LineCoordinates);

                    Feature polygon = new Feature();
                    polygon.type = "Feature";

                    polygon.geometry = new Geometry
                    {
                        type = "Polygon",
                        coordinates = PolygonContainer
                    };

                    polygon.properties = GeojsonProperties;


                    Features.Add(polygon);

                    this.features = Features;

                    break;

                case "LineString":

                    foreach (LatLng latlng in Coordinates)
                    {

                        List<double> Points = new List<double>(){
                            latlng.lng,
                            latlng.lat
                          };

                        LineCoordinates.Add(Points);
                    }

                    Feature linea = new Feature();
                    linea.type = "Feature";

                    linea.geometry = new Geometry
                    {
                        type = "LineString",
                        coordinates = LineCoordinates
                    };

                    linea.properties = GeojsonProperties;

                    Features.Add(linea);

                    this.features = Features;

                    break;

                default:
                    this.features = new List<Feature>();
                    break;
            }
        }

    }

    public class Point : Geojson
    {
        public Point(List<LatLng> Coordinates)
            : base(Coordinates, "Point")
        {

        }

        public Point(List<LatLng> Coordinates, Object PointProperties)
            : base(Coordinates, PointProperties, "Point")
        {

        }
    }

    public class Polygon : Geojson
    {

        public Polygon(List<LatLng> Coordinates)
            : base(Coordinates, "Polygon")
        {

        }


        public Polygon(List<LatLng> Coordinates, Object PolygonProperties)
            : base(Coordinates, PolygonProperties, "Polygon")
        {

        }
    }

    public class LineString : Geojson
    {

        public LineString(List<LatLng> Coordinates)
            : base(Coordinates, "LineString")
        {

        }


        public LineString(List<LatLng> Coordinates, Object PolylineProperties)
            : base(Coordinates, PolylineProperties, "LineString")
        {


        }

    }

    public class LatLng
    {
        public double lat { get; set; }
        public double lng { get; set; }

        public LatLng(double lat, double lng)
        {
            this.lat = lat;
            this.lng = lng;
        }


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
        public string Color { get; set; }

    }

    public class PolygonProperties
    {
        public string FeatureType { get; set; }
        public string Color { get; set; }

    }

    public class PointProperties
    {
        public string FeatureType { get; set; }
        public Double Lat { get; set; }
        public Double Lng { get; set; }

    }


}
