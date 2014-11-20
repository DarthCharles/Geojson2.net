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

        private static string cadena_Conexion = "Data Source=java.isi.uson.mx;Initial Catalog=DIDCOMDDAY;User ID=Alien;Password=Pringles92";

        public Geojson obtener_DatosGPS()
        {

            Geojson a = new Geojson();


            DataTable dataT = new DataTable();
            using (SqlConnection conn = new SqlConnection(cadena_Conexion))
            {
                string query = "select  * from DatosGPS inner join RecorridoDatosGPS on DatosGPS.iID = RecorridoDatosGPS.DatosGPSId  where RecorridoDatosGPS.RecorridoId = 21586 order by iID asc ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dataT);



                    List<List<double>> multiple = new List<List<double>>();
                    List<double> point = new List<double>() { 

                    
                    23.6266557, -102.5375005
                    
                    };
                    List<Feature> puntos = new List<Feature>();

                    foreach (DataRow row in dataT.Rows)
                    {

                        Feature tempFeature = new Feature();
                        tempFeature.type = "Feature";
                        tempFeature.geometry = new Geometry{
                        type = "Point",
                        coordinates = new List<double>(){
                          Double.Parse(row["Longitud"].ToString()),
                          Double.Parse(row["Latitud"].ToString())
                        }
                        };
                        tempFeature.properties = new MarkerProperties()
                        {
                            idMarker = "Recorrido Mex-Toluca",
                            Velocidad = row["Latitud"].ToString(),
                            Fecha = row["Fecha"].ToString()
                            
                        };

                        puntos.Add(tempFeature);
                    }

                   



                    a.type = "FeatureCollection";
                    a.features = puntos;



                    conn.Close();
                }
            }
            return a;
        }


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
            int cont = 0;
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
                    idMarker = "123456 " +  cont,
                    Velocidad = "venus",
                    Fecha = DateTime.Today.ToString()

                };

                puntos.Add(tempFeature);
                cont++;
                i++;
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
                idRecorrido = "Recorrido Mex-Toluca",
                Color = "#12345"
                
          

            };

            puntos.Add(linea);

            datos.type = "FeatureCollection";
            datos.features = puntos;

            return datos;
        }


        static void Main(string[] args)
        {
            Program jsona = new Program();
            string json = JsonConvert.SerializeObject(jsona.getGeojson(), Formatting.Indented);

            using (StreamWriter writer = new StreamWriter("C:\\Carlos\\important.json"))
            {
                writer.Write(json);

            }
        }
    }
}
