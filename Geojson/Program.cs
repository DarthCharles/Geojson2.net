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
                        tempFeature.properties = new Properties()
                        {
                            idMarcador = "Recorrido Mex-Toluca",
                            velocidad = row["Latitud"].ToString(),
                            fecha = row["Fecha"].ToString()
                            
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
        static void Main(string[] args)
        {
            Program jsona = new Program();
            string json = JsonConvert.SerializeObject(jsona.obtener_DatosGPS(), Formatting.Indented);

            using (StreamWriter writer = new StreamWriter("C:\\Users\\Admin\\Documents\\Visual Studio 2013\\Projects\\DIDCOM_ASP\\DIDCOM_ASP\\js\\important.json"))
            {
                writer.Write(json);

            }
        }
    }
}
