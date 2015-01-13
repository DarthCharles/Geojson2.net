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

        public Geojson Point(List<LatLng> Coordinates, Object PointProperties)
        {
            Geojson Point = new Geojson();
            List<Feature> Features = new List<Feature>();

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

                tempFeature.properties = PointProperties;

                Features.Add(tempFeature);

            }

            Point.type = "FeatureCollection";
            Point.features = Features;

            return Point;
        }

        public Geojson Point(List<LatLng> Coordinates)
        {
            Geojson Point = new Geojson();
            List<Feature> Features = new List<Feature>();

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

            Point.type = "FeatureCollection";
            Point.features = Features;

            return Point;

        }

        public Geojson Polygon(List<LatLng> Coordinates)
        {
            Geojson Polygon = new Geojson();
            List<Feature> Features = new List<Feature>();
            List<List<Double>> LineCoordinates = new List<List<double>>();
            List<List<List<Double>>> PolygonContainer = new List<List<List<Double>>>();

            foreach (LatLng latlng in Coordinates)
            {

                List<double> lista = new List<double>()
                 {
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
                Area = Math.Abs(Coordinates.Take(Coordinates.Count - 1)
                .Select((p, i) => (Coordinates[i + 1].lat - p.lat) * (Coordinates[i + 1].lng + p.lng))
                .Sum() / 2),
                Color = "#3289c7"
            };


            Features.Add(polygon);

            Polygon.type = "FeatureCollection";
            Polygon.features = Features;

            return Polygon;

        }

        public Geojson Polygon(List<LatLng> Coordinates, Object PolygonProperties)
        {
            Geojson Polygon = new Geojson();
            List<Feature> Features = new List<Feature>();
            List<List<Double>> LineCoordinates = new List<List<double>>();
            List<List<List<Double>>> PolygonContainer = new List<List<List<Double>>>();

            foreach (LatLng latlng in Coordinates)
            {

                List<double> Points = new List<double>()
                 {
                      latlng.lng,
                      latlng.lat
                  
                 };

                LineCoordinates.Add(Points);

            }

            PolygonContainer.Add(LineCoordinates);


            Feature polygon = new Feature();
            polygon.type = "Feature";

            polygon.geometry = new Geometry
            {
                type = "Polygon",
                coordinates = PolygonContainer
            };

            polygon.properties = PolygonProperties;


            Features.Add(polygon);

            Polygon.type = "FeatureCollection";
            Polygon.features = Features;

            return Polygon;

        }

        public Geojson LineString(List<LatLng> Coordinates)
        {

            Geojson LineString = new Geojson();
            List<Feature> Features = new List<Feature>();
            List<List<Double>> LineCoordinates = new List<List<double>>();

            foreach (LatLng latlng in Coordinates)
            {

                List<double> Points = new List<double>()
                          {
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

            LineString.type = "FeatureCollection";
            LineString.features = Features;


            return LineString;
        }

                public Geojson LinseString(List<LatLng> Coordinates, Object PolylineProperties)
        {

            Geojson LineString = new Geojson();
            List<Feature> Features = new List<Feature>();
            List<List<Double>> LineCoordinates = new List<List<double>>();

            foreach (LatLng latlng in Coordinates)
            {

                List<double> Points = new List<double>()
                          {
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

            linea.properties = PolylineProperties;

            Features.Add(linea);

            LineString.type = "FeatureCollection";
            LineString.features = Features;


            return LineString;
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
        public Double Distance { get; set; }
        public string Color { get; set; }

    }

    public class PolygonProperties
    {
        public string FeatureType { get; set; }
        public Double Area { get; set; }
        public string Color { get; set; }

    }

    public class PointProperties
    {
        public string FeatureType { get; set; }
        public Double Lat { get; set; }
        public Double Lng { get; set; }

    }


}
