using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geojson
{
    class Program
    {

        public Geojson getGeojson()
        {
            Geojson datos = new Geojson();

            List<double> coordenadas = new List<double> {
-110.9547398, 29.0590521,
-110.9546175, 29.0596939,
-110.9545601, 29.0601006,
-110.9545981, 29.0601006,
-110.9541662, 29.0590499,
-110.9540405, 29.0596921,
-110.9539799, 29.0601014,
-110.9540179, 29.0601014
        };

            List<Feature> puntos = new List<Feature>();

            for (int i = 0; i < coordenadas.Count - 1; i++)
            {
                Feature tempFeature = new Feature();
                tempFeature.type = "Feature";
                tempFeature.geometry = new Geometry
                {
                    type = "Point",
                    coordinates = new List<double>(){
                    
                      coordenadas[i],
                        coordenadas[i + 1]
                        }
                };
                tempFeature.properties = new MarkerProperties()
                {
                    FeatureType = "Point",
                    Fecha = DateTime.Today.ToString()

                };

                puntos.Add(tempFeature);

            }

            List<List<Double>> coordenadasLinea = new List<List<double>>();

            for (int i = 0; i < coordenadas.Count - 1; i++)
            {
                List<double> lista = new List<double>();
                lista.Add(coordenadas[i]);
                lista.Add(coordenadas[i + 1]);
                coordenadasLinea.Add(lista);
                i++;
            }

            Feature linea = new Feature();
            linea.type = "Feature";
            linea.geometry = new Geometry
            {
                type = "LineString",
                coordinates = coordenadasLinea
            };
            linea.properties = new PolylineProperties()
            {
                FeatureType = "LineString"

            };

            puntos.Add(linea);

            datos.type = "FeatureCollection";
            datos.features = puntos;

            return datos;
        }

        public Geojson getPolygonGeojson()
        {
            Geojson datos = new Geojson();
            List<Feature> puntos = new List<Feature>();

            List<double> coordenadas = new List<double> {
-110.9547398, 29.0590521,
-110.9546175, 29.0596939,
-110.9545601, 29.0601006,
-110.9545981, 29.0601006,
-110.9541662, 29.0590499,
-110.9540405, 29.0596921,
-110.9539799, 29.0601014,
-110.9540179, 29.0601014
        };

            List<List<Double>> coordenadasLinea = new List<List<double>>();
            List<List<List<Double>>> polygonContainer = new List<List<List<Double>>>();



            for (int i = 0; i < coordenadas.Count - 1; i++)
            {
                List<double> lista = new List<double>();
                lista.Add(coordenadas[i]);
                lista.Add(coordenadas[i + 1]);
                coordenadasLinea.Add(lista);
                i++;
            }

            polygonContainer.Add(coordenadasLinea);


            Feature polygon = new Feature();
            polygon.type = "Feature";

            polygon.geometry = new Geometry
            {
                type = "Polygon",
                coordinates = polygonContainer
            };
            polygon.properties = new PolygonProperties()
            {
                FeatureType = "Polygon",
            };


            puntos.Add(polygon);




            datos.type = "FeatureCollection";
            datos.features = puntos;

            return datos;
        }
        static void Main(string[] args)
        {
            Program jsona = new Program();
            string json = JsonConvert.SerializeObject(jsona.getPolygonGeojson(), Formatting.Indented);

            using (StreamWriter writer = new StreamWriter("C:\\Carlos\\important.json"))
            {
                writer.Write(json);

            }
        }
    }
}
