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
          -110.971301,   29.098372,
          -110.971145,  29.097343,
         -110.970974,   29.096256, 
          -110.970809,   29.095217,
           -110.970620,  29.094172,
          -110.970447,   29.093150,
        -110.970270,    29.092086, 
          -110.970099,   29.091031,
          -110.969927,   29.090140,
        -110.968806,    29.089460, 
         -110.967792,    29.089001,
           -110.966786,  29.088598,
         -110.965806,    29.088233,
           -110.964837,  29.087841,
          -110.963951,  29.087124, 
         -110.962905,   29.086130, 
            -110.961736, 29.085047,
          -110.960322,   29.084261,
          -110.959705 ,  29.083658
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
-110.9541662, 29.0590499,

-110.9546175, 29.0596939,
-110.9540405, 29.0596921,

-110.9545601, 29.0601006,
-110.9539799, 29.0601014,

-110.9545981, 29.0601006,
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
